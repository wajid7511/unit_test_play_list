using System;
using AutoMapper;
using GraphQl.Abstraction.Patients;
using GraphQl.Abstraction.Patients.Models;
using GraphQl.API.Inputs;
using GraphQl.API.Schemas;
using GraphQl.DataBase;

namespace GraphQl.API.Mutations;

public class PatientMutation
{
    public async ValueTask<IQueryable<PatientSchema>> AddProduct(
           PatientInput request,
             GraphQlUnitTestDatabaseContext databaseContext,
           [Service] IMapper mapper,
           [Service] IPatientManager productManager
       )
    {
        PatientDto patientDto = new()
        {
            Name = request.Name,
        };
        var id = await productManager.AddPatientAsync(patientDto);
        if (id > 0)
        {
            var query = databaseContext.Patients.Where(p => p.Id == id);
            return mapper.ProjectTo<PatientSchema>(query);
        }
        return new List<PatientSchema>().AsQueryable();
    }
}
