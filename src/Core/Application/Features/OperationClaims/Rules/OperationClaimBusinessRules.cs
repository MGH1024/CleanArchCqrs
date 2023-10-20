using Application.Features.OperationClaims.Constants;
using Application.Interfaces.UnitOfWork;
using MGH.Core.Application.Rules;
using MGH.Core.CrossCutting.Exceptions.Types;
using MGH.Core.Security.Entities;

namespace Application.Features.OperationClaims.Rules;

public class OperationClaimBusinessRules : BaseBusinessRules
{
    private readonly IUnitOfWork _unitOfWork;

    public OperationClaimBusinessRules(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public Task OperationClaimShouldExistWhenSelected(OperationClaim operationClaim)
    {
        if (operationClaim == null)
            throw new BusinessException(OperationClaimsMessages.NotExists);
        return Task.CompletedTask;
    }

    public async Task OperationClaimIdShouldExistWhenSelected(int id)
    {
        bool doesExist = await _unitOfWork.OperationClaimRepository.AnyAsync(predicate: b => b.Id == id, enableTracking: false);
        if (doesExist)
            throw new BusinessException(OperationClaimsMessages.NotExists);
    }

    public async Task OperationClaimNameShouldNotExistWhenCreating(string name)
    {
        bool doesExist = await _unitOfWork.OperationClaimRepository.AnyAsync(predicate: b => b.Name == name, enableTracking: false);
        if (doesExist)
            throw new BusinessException(OperationClaimsMessages.AlreadyExists);
    }

    public async Task OperationClaimNameShouldNotExistWhenUpdating(int id, string name)
    {
        bool doesExist = await _unitOfWork.OperationClaimRepository.AnyAsync(predicate: b => b.Id != id && b.Name == name, enableTracking: false);
        if (doesExist)
            throw new BusinessException(OperationClaimsMessages.AlreadyExists);
    }
}
