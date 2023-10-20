using System.Linq.Expressions;
using Application.Features.Users.Rules;
using Application.Interfaces.Security;
using Application.Interfaces.UnitOfWork;
using MGH.Core.Persistence.Paging;
using MGH.Core.Security.Entities;
using Microsoft.EntityFrameworkCore.Query;

namespace Infrastructures.Security;

public class UserManager : IUserService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly UserBusinessRules _userBusinessRules;

    public UserManager(IUnitOfWork unitOfWork, UserBusinessRules userBusinessRules)
    {
        _unitOfWork = unitOfWork;
        _userBusinessRules = userBusinessRules;
    }

    public async Task<User> GetAsync(
        Expression<Func<User, bool>> predicate,
        Func<IQueryable<User>, IIncludableQueryable<User, object>> include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        User user = await _unitOfWork.UserRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return user;
    }

    public async Task<IPaginate<User>> GetListAsync(
        Expression<Func<User, bool>> predicate = null,
        Func<IQueryable<User>, IOrderedQueryable<User>> orderBy = null,
        Func<IQueryable<User>, IIncludableQueryable<User, object>> include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<User> userList = await _unitOfWork.UserRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return userList;
    }

    public async Task<User> AddAsync(User user)
    {
        await _userBusinessRules.UserEmailShouldNotExistsWhenInsert(user.Email);

        User addedUser = await _unitOfWork.UserRepository.AddAsync(user);

        return addedUser;
    }

    public async Task<User> UpdateAsync(User user)
    {
        await _userBusinessRules.UserEmailShouldNotExistsWhenUpdate(user.Id, user.Email);

        User updatedUser = await _unitOfWork.UserRepository.UpdateAsync(user);

        return updatedUser;
    }

    public async Task<User> DeleteAsync(User user, bool permanent = false)
    {
        User deletedUser = await _unitOfWork.UserRepository.DeleteAsync(user);

        return deletedUser;
    }
}
