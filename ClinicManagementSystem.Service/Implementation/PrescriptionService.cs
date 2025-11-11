using ClinicManagementSystem.Domain.Models;
using ClinicManagementSystem.Repository.Interface;
using ClinicManagementSystem.Service.Interface;
using Microsoft.EntityFrameworkCore;

namespace ClinicManagementSystem.Service.Implementation;

public class PrescriptionService : IPrescriptionService
{
    private readonly IRepository<Prescription> _repository;

    public PrescriptionService(IRepository<Prescription> repository)
    {
        _repository = repository;
    }

    public List<Prescription> GetAll()
    {
        return _repository.GetAll(selector: x => x).ToList();
    }

    public Prescription? GetById(Guid id)
    {
        return _repository.Get(selector: x => x,
            predicate: x => x.Id == id,
            include: x => x.Include(y => y.Appointment));
    }

    public Prescription Insert(Prescription prescription)
    {
        return _repository.Insert(prescription);
    }

    public Prescription Update(Prescription prescription)
    {
        return _repository.Update(prescription);
    }

    public Prescription? DeleteById(Guid id)
    {
        var prescription = GetById(id);
        return _repository.Delete(prescription);
    }
}