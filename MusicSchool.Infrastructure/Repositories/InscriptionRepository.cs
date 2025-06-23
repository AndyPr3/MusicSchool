using Dapper;
using MusicSchool.Application.DTOs;
using MusicSchool.Application.Inferfaces;
using MusicSchool.Domain.Entities;
using MusicSchool.Domain.Interfaces;
using MusicSchool.Infrastructure.Data;
using System.Data;
using static Dapper.SqlMapper;

namespace MusicSchool.Infrastructure.Repositories
{
    public class InscriptionRepository : IInscriptionRepository, IInscriptionQueries
    {
        private readonly DataBaseContext _ctx;
        public InscriptionRepository(DataBaseContext ctx)
        {
            _ctx = ctx;
        }
        public async Task<int> AddAsync(Inscription entity)
        {
            using var conn = _ctx.CreateConnection();
            var p = new DynamicParameters();
            p.Add("@StudentId", entity.StudentId);
            p.Add("@TeacherId", entity.TeacherId);
            return await conn.ExecuteAsync("sp_CreateInscription", p, commandType: CommandType.StoredProcedure);
        }

        public async Task<int> DeleteAsync(int id)
        {
            using var conn = _ctx.CreateConnection();
            var p = new { Id = id };
            return await conn.ExecuteAsync("sp_DeleteInscription", p, commandType: CommandType.StoredProcedure);
        }

        public async Task<List<Inscription>> GetAllAsync()
        {
            using var conn = _ctx.CreateConnection();
            var sql = "dbo.sp_GetAllInscriptions";

            var inscriptions = await conn.QueryAsync<Inscription, Student, Teacher, Inscription>(
                sql,
                map: (insc, student, teacher) =>
                {
                    insc.Student = student;
                    insc.Teacher = teacher;
                    return insc;
                },
                splitOn: "StudentId,TeacherId",
                commandType: CommandType.StoredProcedure
            );

            return inscriptions.ToList();
        }

        public async Task<Inscription> GetByIdAsync(int id)
        {
            using var conn = _ctx.CreateConnection();
            var p = new { Id = id };

            var inscriptions = await conn.QueryAsync<Inscription, Student, Teacher, Inscription>(
                "sp_GetInscriptionById",
                map: (insc, student, teacher) =>
                {
                    insc.Student = student;
                    insc.Teacher = teacher;
                    return insc;
                },
                param: p,
                splitOn: "StudentId,TeacherId",
                commandType: CommandType.StoredProcedure
            );

            return inscriptions.FirstOrDefault();
        }

        public async Task<int> UpdateAsync(Inscription entity)
        {
            using var conn = _ctx.CreateConnection();
            var p = new DynamicParameters();
            p.Add("@StudentId", entity.StudentId);
            p.Add("@TeacherId", entity.TeacherId);
            return await conn.ExecuteAsync("sp_UpdateInscription", p, commandType: CommandType.StoredProcedure);
        }

        public async Task<List<StudentWithSchoolDto>> GetStudentsByTeacherAsync(int teacherId)
        {
            using var conn = _ctx.CreateConnection();
            var dtos = await conn.QueryAsync<StudentWithSchoolDto>(
                "dbo.sp_GetStudentsByTeacher",
                new { TeacherId = teacherId },
                commandType: CommandType.StoredProcedure);

            return dtos.ToList();
        }

    }
}
