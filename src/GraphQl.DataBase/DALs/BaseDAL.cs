using GraphQl.Common.Database;

namespace GraphQl.DataBase.DALs
{
    public abstract class BaseDAL(GraphQlUnitTestDatabaseContext databaseContext)
    {
        private readonly GraphQlUnitTestDatabaseContext _databaseContext =
                databaseContext ?? throw new ArgumentNullException(nameof(databaseContext));

        protected async ValueTask<DbAddResult<T>> AddAsync<T>(T entity, CancellationToken cancellationToken = default)
            where T : class
        {
            try
            {
                var dbAddResult = await _databaseContext.AddAsync(entity, cancellationToken);
                var result = await _databaseContext.SaveChangesAsync(cancellationToken);
                if (result > 0)
                {
                    return new DbAddResult<T>(true, dbAddResult.Entity);
                }
                else
                {
                    return new DbAddResult<T>(false);
                }
            }
            catch (Exception ex)
            {
                return new DbAddResult<T>(ex);
            }
        }
    }
}