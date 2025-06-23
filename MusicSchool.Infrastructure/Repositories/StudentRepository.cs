using Dapper;
using MusicSchool.Domain.Entities;
using MusicSchool.Domain.Interfaces;
using MusicSchool.Infrastructure.Data;
using System.Data;
using static Dapper.SqlMapper;

namespace MusicSchool.Infrastructure.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        private readonly DataBaseContext _ctx;
        public StudentRepository(DataBaseContext ctx)
        {
            _ctx = ctx;
        }
        public async Task<int> AddAsync(Student entity)
        {
            using var conn = _ctx.CreateConnection();
            var p = new DynamicParameters();
            p.Add("@IdentificationNumber", entity.IdentificationNumber);
            p.Add("@FirstName", entity.FirstName);
            p.Add("@LastName", entity.LastName);
            p.Add("@BirthDate", entity.Birthdate);
            return await conn.ExecuteAsync("sp_CreateStudent", p, commandType: CommandType.StoredProcedure);
        }

        public async Task<int> DeleteAsync(int id)
        {
            using var conn = _ctx.CreateConnection();
            var p = new { Id = id };
            return await conn.ExecuteAsync("sp_DeleteStudent", p, commandType: CommandType.StoredProcedure);
        }

        public async Task<List<Student>> GetAllAsync()
        {
            using var conn = _ctx.CreateConnection();
            var students = await conn.QueryAsync<Student>(
                "dbo.sp_GetAllStudents",
                commandType: CommandType.StoredProcedure);

            return students.ToList();
        }

        public async Task<Student> GetByIdAsync(int id)
        {
            using var conn = _ctx.CreateConnection();
            var p = new { Id = id };
            return await conn.QuerySingleOrDefaultAsync<Student>("sp_GetStudentById", p, commandType: CommandType.StoredProcedure);
        }

        public async Task<int> UpdateAsync(Student entity)
        {
            using var conn = _ctx.CreateConnection();
            var p = new DynamicParameters();
            p.Add("@Id", entity.Id);
            p.Add("@IdentificationNumber", entity.IdentificationNumber);
            p.Add("@FirstName", entity.FirstName);
            p.Add("@LastName", entity.LastName);
            p.Add("@BirthDate", entity.Birthdate);
            return await conn.ExecuteAsync("sp_UpdateStudent", p, commandType: CommandType.StoredProcedure);
        }
    }
}
