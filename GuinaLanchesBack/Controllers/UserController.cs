using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Cors;
using System.Collections.Generic;


namespace GuinaLanchesBack.Controllers;

using System.Runtime.InteropServices;
using DTO;
using Microsoft.AspNetCore.Cors;
using Services;
using Trevisharp.Security.Jwt;

[ApiController]
[Route("user")]
public class UserController : ControllerBase
{
    [HttpPost("login")]
    [EnableCors("DefaultPolicy")]

    public async Task<IActionResult> Login(
        [FromBody] UserData user,
        [FromServices] IUserService service,
        [FromServices] ISecurityService security,
        [FromServices] CryptoService crypto
    )
    {
        var loginUser = await service
            .GetByLogin(user.Login);

        var password = await security.HashPassword(
            user.Password, loginUser.Salt
        );

        var realPassword = loginUser.Password;

        if(password != realPassword)
            return Unauthorized("Senha incorreta!");
        
        var jwt = crypto.GetToken(new { id = loginUser.Id});
        return Ok(new { jwt });
    }

    [HttpPost("register")]
    [EnableCors("DefaultPolicy")]
    public async Task<IActionResult> Create(
        [FromBody] UserData user,
        [FromServices] IUserService service)
    {
        var errors = new List<string>();

        if(user is null || user.Login is null)
            errors.Add("É necessario informar o login!");

        if(user.Login.Length < 5)
            errors.Add("O Login deve conter ao menos 5 caracteres!");

        if(errors.Count > 0)
            return BadRequest(errors);

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
