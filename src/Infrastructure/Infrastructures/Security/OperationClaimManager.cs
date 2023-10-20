using System.Linq.Expressions;
using Application.Features.OperationClaims.Rules;
using Application.Interfaces.Security;
using Application.Interfaces.UnitOfWork;
using MGH.Core.Persistence.Paging;
using MGH.Core.Security.Entities;
using Microsoft.EntityFrameworkCore.Query;

namespace Infrastructures.Security;

public class OperationClaimManager : IOperationClaimService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly OperationClaimBusinessRules _operationClaimBusinessRules;

    public OperationClaimManager(
        OperationClaimBusinessRules operationClaimBusinessRules, IUnitOfWork unitOfWork)
    {
        _operationClaimBusinessRules = operationClaimBusinessRules;
        _unitOfWork = unitOfWork;
    }

    public async Task<OperationClaim> GetAsync(
        Expression<Func<OperationClaim, bool>> predicate,
        Func<IQueryable<OperationClaim>, IIncludableQueryable<OperationClaim, object>> include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        OperationClaim operationClaim = await _unitOfWork.OperationClaimRepository.GetAsync(
            predicate,
            include,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return operationClaim;
    }

    public async Task<IPaginate<OperationClaim>> GetListAsync(
        Expression<Func<OperationClaim, bool>> predicate = null,
        Func<IQueryable<OperationClaim>, IOrderedQueryable<OperationClaim>> orderBy = null,
        Func<IQueryable<OperationClaim>, IIncludableQueryable<OperationClaim, object>> include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<OperationClaim> operationClaimList = await _unitOfWork.OperationClaimRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return operationClaimList;
    }

    public async Task<OperationClaim> AddAsync(OperationClaim operationClaim)
    {
        await _operationClaimBusinessRules.OperationClaimNameShouldNotExistWhenCreating(operationClaim.Name);

        OperationClaim addedOperationClaim = await _unitOfWork.OperationClaimRepository.AddAsync(operationClaim);

        return addedOperationClaim;
    }

    public async Task<OperationClaim> UpdateAsync(OperationClaim operationClaim)
    {
        await _operationClaimBusinessRules.OperationClaimNameShouldNotExistWhenUpdating(operationClaim.Id, operationClaim.Name);

        OperationClaim updatedOperationClaim = await _unitOfWork.OperationClaimRepository.UpdateAsync(operationClaim);

        return updatedOperationClaim;
    }

    public async Task<OperationClaim> DeleteAsync(OperationClaim operationClaim, bool permanent = false)
    {
        OperationClaim deletedOperationClaim = await _unitOfWork.OperationClaimRepository.DeleteAsync(operationClaim);

        return deletedOperationClaim;
    }
}
