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
        User user = new User();
        var salt = await security.GenerateSalt();

        user.Email = data.Login;
        user.Password = await security.HashPassword(
            data.Password, salt
        );
        user.Salt = salt;

        this.ctx.Add(user);
        await this.ctx.SaveChangesAsync();
    }

    public async Task<User> GetByLogin(string login)
    {
        var query = 
            from c in this.ctx.Users
            where c.Email == login
            select c;

        return await query.FirstOrDefaultAsync();
    }

    Task<User> IUserService.GetByLogin(string login)
    {
        throw new NotImplementedException();
    }
}