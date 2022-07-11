using domain.Core.Interfaces.Repositories;
using domain.Domain.Core;
using infra.Data;

namespace infra.Repository.Persistence
{
  public class UserRepository : RepositoryBase<Users>, IUserRepository
  {
    private readonly SqlContext sqlContext;

    public UserRepository(SqlContext sqlContext): base(sqlContext)
    {
      this.sqlContext = sqlContext;
    }
  }
}