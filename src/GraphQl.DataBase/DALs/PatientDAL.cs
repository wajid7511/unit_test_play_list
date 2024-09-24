using System.Linq.Expressions;
using GraphQl.Common.Database;
using GraphQl.DataBase.Models;
using Microsoft.EntityFrameworkCore;

namespace GraphQl.DataBase.DALs;

public class PatientDAL(GraphQlUnitTestDatabaseContext databaseContext) : BaseDAL(databaseContext)
{
    private readonly GraphQlUnitTestDatabaseContext _databaseContext = databaseContext;

    public virtual async ValueTask<DbAddResult<Patient>> AddPatient_Async(Patient patient,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(patient);
        return await AddAsync(patient, cancellationToken);
    }

    public virtual async ValueTask<DbGetResult<List<Patient>>> GetPatients_Async(
        Expression<Func<Patient, bool>> predicate,
        int take = 10,
        int skip = 0,
        CancellationToken cancellationToken = default
    )
    {
        ArgumentNullException.ThrowIfNull(predicate);
        try
        {
            var query = _databaseContext.Patients.Where(predicate);

            query = query.OrderBy(e => e.Id).Skip(skip).Take(take);

            var result = await query.ToListAsync(cancellationToken: cancellationToken);
            return new DbGetResult<List<Patient>>(result.Count != 0, result);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return new DbGetResult<List<Patient>>(ex);
        }
    }
}
