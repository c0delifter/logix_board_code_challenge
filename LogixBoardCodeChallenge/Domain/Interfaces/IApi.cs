using LogixBoardCodeChallenge.Models;

namespace LogixBoardCodeChallenge.Domain.Interfaces
{
    public interface IApi
    {
        Task<Organization> GetOrganization(string id, CancellationToken cancellationToken);
        Task<Shipment> GetShipment(string id, CancellationToken cancellationToken);
        Task<bool> UpsertOrganization(Organization shipment, CancellationToken cancellationToken);
        Task<bool> UpsertShipment(Shipment shipment, CancellationToken cancellationToken);
    }
}