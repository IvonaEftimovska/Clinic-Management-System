using ClinicManagementSystem.Domain.Models;

namespace ClinicManagementSystem.Service.Interface;

public interface IPatientService
{
    List<Patient> GetAll();
    Patient? GetById(Guid id);
    Patient Insert(Patient patient);
    Patient Update(Patient patient);
    Patient DeleteById(Guid id);
}