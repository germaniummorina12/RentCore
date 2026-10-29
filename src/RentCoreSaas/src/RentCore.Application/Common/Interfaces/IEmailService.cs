namespace RentCore.Application.Common.Interfaces
{
    public interface IEmailService
    {
        Task<bool> SendAsync(int tenantId, IEnumerable<string> recipients, string subject, string body, CancellationToken cancellation);
    }
}
