using ClinicManagementSystem.Domain.Models;

namespace ClinicManagementSystem.Service.Interface;

public interface IDepartmentService
{
    List<Department> GetAll();
    Department? GetById(Guid id);
    Department Insert(Department department);
    Department Update(Department department);
    Department? DeleteById(Guid id);
}