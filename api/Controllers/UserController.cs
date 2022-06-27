using application.Models.InputModels;
using application.Models.ViewModels;
using application.Services.Users;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers;

[ApiController]
[Route("api/usuarios")]
public class UserController : ControllerBase
{
    private readonly ILogger<UserController> logger;
    private readonly IUserApplicationService userService;

    public UserController(ILogger<UserController> logger, IUserApplicationService userService)
    {
        this.logger = logger;
        this.userService = userService;
    }

    // [HttpGet("{id}")]
    // public async Task<UserViewModel> Get(int id)
    // {
    //    return await this.userService.Select(id);
    // }

    [HttpGet]
    public IEnumerable<UserViewModel> List()
    {
        return this.userService.GetAll();
    }

    // [HttpPost]
    // public async Task Save(UserInputModel user)
    // {
    //     await this.userService.Save(user);
    // }
    
    // [HttpDelete]
    // public async Task Delete(int id)
    // {
    //     await this.userService.Delete(id);
    // }
}
