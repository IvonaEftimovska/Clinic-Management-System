using ClinicManagementSystem.Domain.Models;
using ClinicManagementSystem.Repository.Interface;
using ClinicManagementSystem.Service.Interface;
using Microsoft.EntityFrameworkCore;

namespace ClinicManagementSystem.Service.Implementation;

internal class PatientService : IPatientService
{
    private readonly IRepository<Patient> _repository;

    public PatientService(IRepository<Patient> repository)
    {
        _repository = repository;
    }
    
    public List<Patient> GetAll()
    {
        return _repository.GetAll(selector: x => x).ToList();
    }

    public Patient? GetById(Guid id)
    {
        return _repository.Get(selector: x => x, 
            predicate: x => x.Id == id, 
            include: x => x.Include(y => y.Appointments));
    }

    public Patient Insert(Patient patient)
    {
        return _repository.Insert(patient);
    }

    public Patient Update(Patient patient)
    {
        return  _repository.Update(patient);
    }

    public Patient DeleteById(Guid id)
    {
        var patient = GetById(id);
        return _repository.Delete(patient);
    }
    
}