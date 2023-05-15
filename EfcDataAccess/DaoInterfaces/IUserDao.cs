using Domain.DTOs;
using Domain.Models;


public interface IUserDao
{
    Task<User> CreateAsync(User user);
    Task<User?>  GetByUsernameAsync(string userName);
    Task<IEnumerable<User>> GetByUsernameAsync(SearchUserParametersDto searchParameters);
    Task<User?> GetByIdAsync(int id);
}