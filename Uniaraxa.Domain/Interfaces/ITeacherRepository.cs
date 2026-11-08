
using Uniaraxa.Domain.Entities;

namespace Uniaraxa.Domain.Interfaces
{
    public interface ITeacherRepository
    {
        public void AddTeacher(Teacher teacher);
        public void UpdateTeacher(Teacher teacher);
        public void DeleteTeacher(int id);
        public Teacher GetTeacherById(int id);
        public List<Teacher> GetAllTeachers();
    }
}
