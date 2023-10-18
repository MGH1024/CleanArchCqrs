using MGH.Core.Persistence.Repositories;
using MGH.Core.Security.Entities;

namespace Domain.Repositories;

public interface IOtpAuthenticatorRepository : IAsyncRepository<OtpAuthenticator, int>, IRepository<OtpAuthenticator, int> { }
