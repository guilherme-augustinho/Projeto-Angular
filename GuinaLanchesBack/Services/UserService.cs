using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace GuinaLanchesBack.Services;

using DTO;
using Model;

public class UserService : IUserService
{
    GuinaLanchesContext ctx;
    ISecurityService security;
    public UserService(GuinaLanchesContext ctx, ISecurityService security)
    {
        this.ctx = ctx;
        this.security = security;
    }
    public async Task Create(UserData data)
    {
        Cliente cliente = new Cliente();
        var salt = await security.GenerateSalt();

        cliente.Nome = data.Login;
        cliente.Senha = await security.HashPassword(
            data.Password, salt
        );
        cliente.Salt = salt;

        this.ctx.Add(cliente);
        await this.ctx.SaveChangesAsync();
    }

    public async Task<Cliente> GetByLogin(string login)
    {
        var query = 
            from c in this.ctx.Clientes
            where c.Nome == login
            select c;

        return await query.FirstOrDefaultAsync();
    }
}