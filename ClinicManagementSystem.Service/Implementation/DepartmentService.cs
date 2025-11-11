using ClinicManagementSystem.Domain.Models;
using ClinicManagementSystem.Repository.Interface;
using ClinicManagementSystem.Service.Interface;
using Microsoft.EntityFrameworkCore;

namespace ClinicManagementSystem.Service.Implementation;

public class DepartmentService : IDepartmentService
{
    private readonly IRepository<Department> _repository;

    public DepartmentService(IRepository<Department> repository)
    {
        _repository = repository;
    }

    public List<Department> GetAll()
    {
        return _repository.GetAll(selector: x => x).ToList();
    }

    public Department? GetById(Guid id)
    {
        return _repository.Get(selector:x => x,
            predicate: x => x.Id == id,
            include: x => x.Include(y => y.Doctors));
    }

    public Department Insert(Department department)
    {
        return _repository.Insert(department);
    }

    public Department Update(Department department)
    {
        return _repository.Update(department);
    }

    public Department? DeleteById(Guid id)
    {
        var department = GetById(id);
        return _repository.Delete(department);
    }
}