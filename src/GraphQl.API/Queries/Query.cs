using AutoMapper;
using GraphQl.API.Models;
using GraphQl.DataBase;

namespace GraphQl.API.Queries;

public class Query
{
    [UseOffsetPaging(DefaultPageSize = 10, IncludeTotalCount = true, MaxPageSize = 100)]
    [UseProjection]
    [UseFiltering]
    [UseSorting]
    public IQueryable<PatientSchema> GetPatients(
            [Service] GraphQlUnitTestDatabaseContext dbContext,
            [Service] IMapper mapper
        )
    {
        var query = dbContext.Patients.OrderByDescending(p => p.Id).AsQueryable();
        return mapper.ProjectTo<PatientSchema>(query);
    }
}
