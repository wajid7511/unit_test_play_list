using AutoMapper;
using GraphQl.Abstraction.Patients;
using GraphQl.Abstraction.Patients.Models;
using GraphQl.DataBase.DALs;
using GraphQl.DataBase.Models;

namespace GraphQl.Core.Patients;

public class DefaultPatientManager(PatientDAL patientDAL, IMapper mapper) : IPatientManager
{

    private readonly PatientDAL _patientDAL = patientDAL ?? throw new ArgumentNullException(nameof(patientDAL));
    private readonly IMapper _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));

    public async ValueTask<int> AddPatientAsync(
        PatientDto request,
        CancellationToken cancellationToken = default
    )
    {
        ArgumentNullException.ThrowIfNull(request, nameof(request));

        var patient = _mapper.Map<Patient>(request);

        var dbAddResult = await _patientDAL.AddPatient_Async(patient, cancellationToken);

        return dbAddResult.Entity?.Id ?? 0;
    }
}
