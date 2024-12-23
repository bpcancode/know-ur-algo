using API.Persistence.Entities;
using Microsoft.EntityFrameworkCore;

namespace API.Persistence.Repository.Interface;

public interface IUserRepo
{
   Task<User?> GetByUserName(string userName);
}