using ClinicManagementSystem.Domain.Models;
using ClinicManagementSystem.Service.Implementation;

namespace ClinicManagementSystem.Service.Interface;

public interface IPrescriptionService
{
    List<Prescription> GetAll();
    Prescription? GetById(Guid id);
    Prescription Insert(Prescription prescription);
    Prescription Update(Prescription prescription);
    Prescription? DeleteById(Guid id);
}