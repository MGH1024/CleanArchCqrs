using Domain.Repositories;
using MGH.Core.Persistence.Repositories;
using MGH.Core.Security.Entities;
using Microsoft.EntityFrameworkCore;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class EmailAuthenticatorRepository : EfRepositoryBase<EmailAuthenticator, int, AppDbContext>, IEmailAuthenticatorRepository
{
    public EmailAuthenticatorRepository(AppDbContext context)
        : base(context) { }
}
