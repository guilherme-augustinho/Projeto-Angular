using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace GuinaLanchesBack.Services;

using DTO;
using Model;

public class UserService : IUserService
{
    GuinaLanchesContext ctx;
    public UserService(GuinaLanchesContext ctx)
        => this.ctx = ctx;
    public async Task Create(UserData data)
    {
        Cliente cliente =  new Cliente();
        cliente.Nome = data.Login;
        cliente.Senha = data.Password;
        cliente.Salt = "??????";

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