using System.Linq.Expressions;
using Application.Features.UserOperationClaims.Rules;
using Application.Interfaces.Security;
using Application.Interfaces.UnitOfWork;
using MGH.Core.Persistence.Paging;
using MGH.Core.Security.Entities;
using Microsoft.EntityFrameworkCore.Query;

namespace Infrastructures.Security;

public class UserUserOperationClaimManager : IUserOperationClaimService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly UserOperationClaimBusinessRules _userUserOperationClaimBusinessRules;

    public UserUserOperationClaimManager(
        IUnitOfWork unitOfWork,
        UserOperationClaimBusinessRules userUserOperationClaimBusinessRules
    )
    {
        _unitOfWork = unitOfWork;
        _userUserOperationClaimBusinessRules = userUserOperationClaimBusinessRules;
    }

    public async Task<UserOperationClaim> GetAsync(
        Expression<Func<UserOperationClaim, bool>> predicate,
        Func<IQueryable<UserOperationClaim>, IIncludableQueryable<UserOperationClaim, object>> include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        UserOperationClaim userUserOperationClaim = await _unitOfWork.UserOperationClaimRepository.GetAsync(
            predicate,
            include,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return userUserOperationClaim;
    }

    public async Task<IPaginate<UserOperationClaim>> GetListAsync(
        Expression<Func<UserOperationClaim, bool>> predicate = null,
        Func<IQueryable<UserOperationClaim>, IOrderedQueryable<UserOperationClaim>> orderBy = null,
        Func<IQueryable<UserOperationClaim>, IIncludableQueryable<UserOperationClaim, object>> include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<UserOperationClaim> userUserOperationClaimList = await _unitOfWork.UserOperationClaimRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return userUserOperationClaimList;
    }

    public async Task<UserOperationClaim> AddAsync(UserOperationClaim userUserOperationClaim)
    {
        await _userUserOperationClaimBusinessRules.UserShouldNotHasOperationClaimAlreadyWhenInsert(
            userUserOperationClaim.UserId,
            userUserOperationClaim.OperationClaimId
        );

        UserOperationClaim addedUserOperationClaim = await _unitOfWork.UserOperationClaimRepository.AddAsync(userUserOperationClaim);

        return addedUserOperationClaim;
    }

    public async Task<UserOperationClaim> UpdateAsync(UserOperationClaim userUserOperationClaim)
    {
        await _userUserOperationClaimBusinessRules.UserShouldNotHasOperationClaimAlreadyWhenUpdated(
            userUserOperationClaim.Id,
            userUserOperationClaim.UserId,
            userUserOperationClaim.OperationClaimId
        );

        UserOperationClaim updatedUserOperationClaim = await _unitOfWork.UserOperationClaimRepository.UpdateAsync(userUserOperationClaim);

        return updatedUserOperationClaim;
    }

    public async Task<UserOperationClaim> DeleteAsync(UserOperationClaim userUserOperationClaim, bool permanent = false)
    {
        UserOperationClaim deletedUserOperationClaim = await _unitOfWork.UserOperationClaimRepository.DeleteAsync(userUserOperationClaim);

        return deletedUserOperationClaim;
    }
}
