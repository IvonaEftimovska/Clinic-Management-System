using ClinicManagementSystem.Domain.Models;
using ClinicManagementSystem.Repository.Interface;
using ClinicManagementSystem.Service.Interface;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;

namespace ClinicManagementSystem.Service.Implementation;

internal class DoctorService : IDoctorService
{
    private readonly IRepository<Doctor> _repository;

    public DoctorService(IRepository<Doctor> repository)
    {
        _repository = repository;
    }

    public List<Doctor> GetAll()
    {
        return _repository.GetAll(selector: x => x).ToList();
    }

    public Doctor? GetById(Guid id)
    {
        return _repository.Get(selector: x => x, 
            predicate: x => x.Id == id,
            include: x => (IIncludableQueryable<Doctor, object>)
                x.Include(d => d.Patients)
                    .Include(d => d.Appointments));
    }

    public Doctor Insert(Doctor doctor)
    {
        return _repository.Insert(doctor);
    }

    public Doctor Update(Doctor doctor)
    {
        return _repository.Update(doctor);
    }

    public Doctor? DeleteById(Guid id)
    {
        var doctor = GetById(id);
        return _repository.Delete(doctor);
    }
}