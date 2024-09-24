using System;
using GraphQl.Abstraction.Patients.Models;

namespace GraphQl.Abstraction.Patients;

public interface IPatientManager
{
    public ValueTask<int> AddPatientAsync(
            PatientDto request,
            CancellationToken cancellationToken = default
        );
}
