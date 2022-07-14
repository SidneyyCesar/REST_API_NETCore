using application.Models.InputModels;
using application.Models.ViewModels;
using application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers;

[ApiController()]
[Route("usuarios/")]
public class UserController : ControllerBase
{
    private readonly IUserApplicationService userService;

    public UserController(IUserApplicationService userService)
    {
        this.userService = userService;
    }

    [HttpGet]
    public async Task<IEnumerable<UserViewModel>> List()
    {
        return await this.userService.GetAll();
    }

    [HttpGet("{id}")]
    public async Task<UserViewModel> Get(int id)
    {
        return await this.userService.GetById(id);
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
