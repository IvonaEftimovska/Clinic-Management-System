using ClinicManagementSystem.Domain.Models;

namespace ClinicManagementSystem.Service.Interface;

public interface IDoctorService
{
    List<Doctor> GetAll();
    Doctor? GetById(Guid id);
    Doctor Insert(Doctor doctor);
    Doctor Update(Doctor doctor);
    Doctor? DeleteById(Guid id);
}