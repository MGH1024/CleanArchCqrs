using Domain.Identity;

namespace Application.Contracts.Infrastructure.Identity;

public interface IPermissionService
{
    List<Permission> GetAllPermission();
}