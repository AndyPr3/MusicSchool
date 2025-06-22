using Dapper;
using MusicSchool.Domain.Entities;
using MusicSchool.Domain.Interfaces;
using MusicSchool.Infrastructure.Data;
using System.Data;
using static Dapper.SqlMapper;

namespace MusicSchool.Infrastructure.Repositories
{
    public class SchoolRepository : ISchoolRepository
    {
        private readonly DataBaseContext _ctx;
        public SchoolRepository(DataBaseContext ctx)
        {
            _ctx = ctx;
        }
        public async Task<int> AddAsync(School entity)
        {
            using var conn = _ctx.CreateConnection();
            var p = new DynamicParameters();
            p.Add("@Code", entity.Code);
            p.Add("@Name", entity.Name);
            p.Add("@Description", entity.Description);
            return await conn.ExecuteAsync("sp_CreateSchool", p, commandType: CommandType.StoredProcedure);
        }

        public async Task<int> DeleteAsync(int id)
        {
            using var conn = _ctx.CreateConnection();
            var p = new { Id = id };
            return await conn.ExecuteAsync("sp_DeleteSchool", p, commandType: CommandType.StoredProcedure);
        }

        public async Task<List<School>> GetAllAsync()
        {
            using var conn = _ctx.CreateConnection();
            var students = await conn.QueryAsync<School>(
                "dbo.sp_GetAllSchools",
                commandType: CommandType.StoredProcedure);

            return students.ToList();
        }

        public async Task<School> GetByIdAsync(int id)
        {
            using var conn = _ctx.CreateConnection();
            var p = new { Id = id };
            return await conn.QuerySingleOrDefaultAsync<School>("sp_GetSchoolById", p, commandType: CommandType.StoredProcedure);
        }

        public async Task<int> UpdateAsync(School entity)
        {
            using var conn = _ctx.CreateConnection();
            var p = new DynamicParameters();
            p.Add("@Id", entity.Id);
            p.Add("@Code", entity.Code);
            p.Add("@Name", entity.Name);
            p.Add("@Desc", entity.Description);
            return await conn.ExecuteAsync("sp_UpdateSchool", p, commandType: CommandType.StoredProcedure);
        }
    }
}
