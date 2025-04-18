using TeamTaskManagement.Domain.Entities;

namespace TeamTaskManagement.Domain.Interfaces
{
    public interface IUserRepository
    {
        Task<User?> GetByIdAsync(long id);
        Task<User?> GetByUsernameAsync(string username);
        Task<IEnumerable<User>> GetAllAsync();
        Task<bool> DeleteAsync(long id);
        Task<bool> AddUserToTeamAsync(long teamId, long userId);
        Task<bool> RemoveUserToTeamAsync(long userId);
    }
}
