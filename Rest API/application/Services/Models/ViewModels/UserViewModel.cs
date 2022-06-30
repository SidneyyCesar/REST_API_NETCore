namespace application.Models.ViewModels
{
    public class UserViewModel
    {
        public UserViewModel() { }
        public UserViewModel(string name)
        {
            this.name = name;
        }

        public int id { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        public string password { get; set; }
    }
}