using System.Collections.Generic;
using domain.Core.Interfaces.Repositories;
using domain.Domain.Entities;
using infra.Data;

namespace infra.Repository.Persistence
{
  public class UserRepository : RepositoryBase<Users>, IUserRepository
  {
    private readonly SqlContext sqlContext;

    public override IEnumerable<Users> GetAll()
    {
      var listUsers = new List<Users>();

      listUsers.Add(new Users() {
        id = 1,
        name = "Sidney Cesar",
        email = "sidney@hotmail.com"
      });

      listUsers.Add(new Users() {
        id = 2,
        name = "Bruna Santos",
        email = "bruna@hotmail.com"
      });

      listUsers.Add(new Users() {
        id = 3,
        name = "Kleber Santos",
        email = "cleber@hotmail.com"
      });

      return listUsers;
    }

    public UserRepository(SqlContext sqlContext): base(sqlContext)
    {
      this.sqlContext = sqlContext;
    }
  }
}