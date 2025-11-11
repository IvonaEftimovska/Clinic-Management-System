using ClinicManagementSystem.Domain.Models;

namespace ClinicManagementSystem.Service.Interface;

public interface IAppointmentService
{
    List<Appointment> GetAll();
    Appointment? GetById(Guid id);
    Appointment Insert(Appointment appointment);
    Appointment Update(Appointment appointment);
    Appointment? DeleteById(Guid id);
    Appointment CreateAppointment(Guid doctorId, Guid patientId, DateTime date, string time, string? notes = null);

}