using System.Threading.Tasks;
using System.Collections.Generic;


namespace GuinaLanchesBack.Services;

using DTO;
using Model;
public interface IUserService
{
    Task Create(UserData data);
    Task<User> GetByLogin(string login);
}