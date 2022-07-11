using domain.Interfaces.Repositories;

namespace domain.Domain.Core
{
    public class Users: IEntity
    {
        public int id { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public string status { get; set; }

    }
}