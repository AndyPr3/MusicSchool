using Dapper;
using MusicSchool.Domain.Entities;
using MusicSchool.Domain.Interfaces;
using MusicSchool.Infrastructure.Data;
using System.Data;
using static Dapper.SqlMapper;

namespace MusicSchool.Infrastructure.Repositories
{
    public class TeacherRepository : ITeacherRepository
    {
        private readonly DataBaseContext _ctx;
        public TeacherRepository(DataBaseContext ctx)
        {
            _ctx = ctx;
        }
        public async Task<int> AddAsync(Teacher entity)
        {
            using var conn = _ctx.CreateConnection();
            var p = new DynamicParameters();
            p.Add("@IdentificationNumber", entity.IdentificationNumber);
            p.Add("@FirstName", entity.FirstName);
            p.Add("@LastName", entity.LastName);
            p.Add("@SchoolId", entity.SchoolId);
            return await conn.ExecuteAsync("sp_CreateTeacher", p, commandType: CommandType.StoredProcedure);
        }

        public async Task<int> DeleteAsync(int id)
        {
            using var conn = _ctx.CreateConnection();
            var p = new { Id = id };
            return await conn.ExecuteAsync("sp_DeleteTeacher", p, commandType: CommandType.StoredProcedure);
        }

        public async Task<List<Teacher>> GetAllAsync()
        {
            using var conn = _ctx.CreateConnection();
            var Teachers = await conn.QueryAsync<Teacher>(
                "dbo.sp_GetAllTeachers",
                commandType: CommandType.StoredProcedure);

            return Teachers.ToList();
        }

        public async Task<Teacher> GetByIdAsync(int id)
        {
            using var conn = _ctx.CreateConnection();
            var p = new { Id = id };
            return await conn.QuerySingleOrDefaultAsync<Teacher>("sp_GetTeacherById", p, commandType: CommandType.StoredProcedure);
        }

        public async Task<int> UpdateAsync(Teacher entity)
        {
            using var conn = _ctx.CreateConnection();
            var p = new DynamicParameters();
            p.Add("@Id", entity.Id);
            p.Add("@IdentificationNumber", entity.IdentificationNumber);
            p.Add("@FirstName", entity.FirstName);
            p.Add("@LastName", entity.LastName);
            p.Add("@SchoolId", entity.SchoolId);
            return await conn.ExecuteAsync("sp_UpdateTeacher", p, commandType: CommandType.StoredProcedure);
        }
    }
}
