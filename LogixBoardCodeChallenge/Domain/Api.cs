using Google.Cloud.Firestore;
using Google.Cloud.Firestore.V1;
using LogixBoardCodeChallenge.Domain.Interfaces;
using LogixBoardCodeChallenge.Models;
using LogixBoardCodeChallenge.Models.Exceptions;
using Newtonsoft.Json;

namespace LogixBoardCodeChallenge.Domain
{
    public class Api : IApi
    {
        private readonly IFirestoreRepository _fireRepo;
        public Api(IFirestoreRepository fireRepo)
        {
            _fireRepo = fireRepo;
        }

        public async Task<Shipment> GetShipment(string id, CancellationToken cancellationToken)
        {
            try
            {
                var toReturn = await _fireRepo.WhereEqualTo<Shipment>("ReferenceId", id, cancellationToken);
                return toReturn.FirstOrDefault();

            }
            catch (Exception ex)
            {
                throw new FirestoreConnectionException(ex.Message.ToString());
            }
        }

        public async Task<bool> UpsertShipment(Shipment shipment, CancellationToken cancellationToken)
        {
            try
            {
                await _fireRepo.Add(shipment, cancellationToken);
                return true;
            }
            catch (Exception ex)
            {
                throw new FirestoreConnectionException(ex.Message.ToString());
            }
        }

        public async Task<Organization> GetOrganization(string id, CancellationToken cancellationToken)
        {
            try
            {
                var toReturn = await _fireRepo.WhereEqualTo<Organization>("Id", id, cancellationToken);
                return toReturn.FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw new FirestoreConnectionException(ex.Message.ToString());
            }
        }

        public async Task<bool> UpsertOrganization(Organization org, CancellationToken cancellationToken)
        {
            try
            {
                await _fireRepo.Add(org, cancellationToken);
                return true;
            }
            catch (Exception ex)
            {
                throw new FirestoreConnectionException(ex.Message.ToString());
            }
        }
    }
}
