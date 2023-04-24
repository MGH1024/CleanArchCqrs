using Application.Models;
using Application.Models.Email;

namespace Application.Contracts.Infrastructure;

public interface IEmailSender
{
    Task<bool> SendEmail(Email email);
}