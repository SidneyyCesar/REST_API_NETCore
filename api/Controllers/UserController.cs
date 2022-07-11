using application.Models.InputModels;
using application.Models.ViewModels;
using application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers;

[ApiController()]
[Route("usuarios/")]
public class UserController : ControllerBase
{
    private readonly ILogger<UserController> logger;
    private readonly IUserApplicationService userService;

    public UserController(ILogger<UserController> logger, IUserApplicationService userService)
    {
        this.logger = logger;
        this.userService = userService;
    }

    [HttpGet("{id}")]
    public async Task<UserViewModel> Get(int id)
    {
       return await this.userService.GetById(id);
    }

    [HttpGet]
    public async Task<IEnumerable<UserViewModel>> List()
    {
        return await this.userService.GetAll();
    }

    [HttpPost]
    public async Task Save(UserInputModel user)
    {
        await this.userService.Save(user);
    }
    
    [HttpDelete]
    public async Task Delete(int id)
    {
        await this.userService.Remove(id);
    }
}
