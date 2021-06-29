using GymManager.Core.Entities;
using GymManager.Data.Repositories;

namespace GymManager.Core.Services.UserService
{
    public interface IUserRepository: IBaseRepository<Client>
    {
    }
}
