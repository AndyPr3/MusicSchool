using MusicSchool.Application.DTOs;

namespace MusicSchool.Application.Inferfaces
{
    public interface IInscriptionQueries
    {
        Task<List<StudentWithSchoolDto>> GetStudentsByTeacherAsync(int teacherId);
    }
}
