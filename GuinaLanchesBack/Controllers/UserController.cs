using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Cors;


namespace GuinaLanchesBack.Controllers;

using DTO;
using Microsoft.AspNetCore.Cors;
using Services;

[ApiController]
[Route("user")]
public class UserController : ControllerBase
{
    [HttpGet]
    [EnableCors("DefaultPolicy")]

    public async Task<IActionResult> Login(
        [FromBody] UserData user,
        [FromServices] IUserService service)
    {
        var logged = await service
            .GetByLogin(user.Login);

        if(logged.Senha != user.Password)
            return Ok("Deu ruim!!");

        return Ok();
        
    }

    [HttpPost]
    [EnableCors("DefaultPolicy")]
    public async Task<IActionResult> Create(
        [FromBody] UserData user,
        [FromServices] IUserService service)
    {
        await service.Create(user);
        return Ok();
    }

    [HttpDelete]
    [EnableCors("DefaultPolicy")]

    public IActionResult DeleteUser()
    {
        throw new NotImplementedException();
    }

}
