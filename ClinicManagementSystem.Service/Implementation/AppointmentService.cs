using ClinicManagementSystem.Domain.Models;
using ClinicManagementSystem.Repository.Interface;
using ClinicManagementSystem.Service.Interface;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;

namespace ClinicManagementSystem.Service.Implementation;

public class AppointmentService : IAppointmentService
{
    private readonly IRepository<Appointment> _repository;
    private readonly IRepository<Doctor> _doctorRepository;
    private readonly IRepository<Patient> _patientRepository;

    public AppointmentService(IRepository<Appointment> repository,
        IRepository<Doctor> doctorRepository,
        IRepository<Patient> patientRepository)
    {
        _repository = repository;
        _doctorRepository = doctorRepository;
        _patientRepository = patientRepository;
    }

    public List<Appointment> GetAll()
    {
        return _repository.GetAll(selector: x => x).ToList();
    }

    public Appointment? GetById(Guid id)
    {
        return _repository.Get(selector: x => x,
            predicate: x  => x.Id == id,
            include: x => (IIncludableQueryable<Appointment, object>)x
                .Include(y => y.Patient)
                .Include(y => y.Doctor)
                .Include(y => y.Prescription));
    }

    public Appointment Insert(Appointment appointment)
    {
        return _repository.Insert(appointment);
    }

    public Appointment Update(Appointment appointment)
    {
        return _repository.Update(appointment);
    }

    public Appointment? DeleteById(Guid id)
    {
        var appointment = GetById(id);
        return _repository.Delete(appointment);
    }

    public Appointment CreateAppointment(Guid doctorId, Guid patientId, DateTime date, string time, string? notes = null)
    {
        var appointment = new Appointment
        {
            Id = Guid.NewGuid(),
            DoctorId = doctorId,
            PatientId = patientId,
            Date = date,
            Time = time,
            Notes = notes
        };
        _repository.Insert(appointment);
        return appointment;
    }
}