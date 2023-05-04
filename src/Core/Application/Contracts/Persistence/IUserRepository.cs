using Application.Models;
using Domain.Identity;

namespace Application.Contracts.Persistence
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetAllUsers(GetParameter getParameter);
        Task<User> GetByIdAsync(int userId);
        Task InsertUserRefreshToken(UserRefreshToken userRefreshToken);
        UserRefreshToken GetUserRefreshTokenByUserAndOldToken(User user, string token, string refreshToken);
        Task InvalidateRefreshToken(string refreshToken);
    }
}
