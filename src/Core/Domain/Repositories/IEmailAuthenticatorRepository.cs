using MGH.Core.Persistence.Repositories;
using MGH.Core.Security.Entities;

namespace Domain.Repositories;

public interface IEmailAuthenticatorRepository : IAsyncRepository<EmailAuthenticator, int>,
    IRepository<EmailAuthenticator, int>
{
}