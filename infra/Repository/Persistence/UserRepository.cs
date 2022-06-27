using domain.Domain.Entities;
using infra.Data;
using infra.Repository.interfaces;

namespace infra.Repository.Persistence
{
  public class UserRepository : RepositoryBase<User>, IUserRepository
  {
    private readonly SqlContext sqlContext;

    public UserRepository(SqlContext sqlContext): base(sqlContext)
    {
      this.sqlContext = sqlContext;
    }

  }
}