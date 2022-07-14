using domain.Core.Interfaces.Repositories;
using domain.Domain.Core;
using infra.Data;
using Microsoft.Extensions.Logging;

namespace infra.Repository.Persistence
{
  public class UserRepository : RepositoryBase<Users>, IUserRepository
  {
    private readonly SqlContext sqlContext;
    public UserRepository(SqlContext sqlContext, ILoggerFactory loggerFactory): base(sqlContext)
    {
      this.sqlContext = sqlContext;
    }
  }
}