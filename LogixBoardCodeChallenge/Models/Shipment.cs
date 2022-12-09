using Google.Cloud.Firestore;
using Newtonsoft.Json;

namespace LogixBoardCodeChallenge.Models
{
    [FirestoreData]
    public class Shipment : FirestoreCollectionItem
    {
        //private readonly string _id;
        //private readonly string _type;
        //private readonly IEnumerable<string> _organizations;
        //private readonly DateTime _estimatedTimeArrival;
        //private readonly TransportPack _transportPacks;

        //public Shipment(string referenceId, string type, IEnumerable<string> organizations, DateTime estimatedTimeArrival, TransportPack transportPacks)
        //{
        //    _id = referenceId;
        //    _type = type;
        //    _organizations = organizations;
        //    _estimatedTimeArrival = estimatedTimeArrival;
        //    _transportPacks = transportPacks;
        //}

        [FirestoreProperty]
        [JsonProperty("ReferenceId")]
        public string? Id { get; set; }
        [FirestoreProperty]
        public string? Type { get; set; }
        [FirestoreProperty]
        public IEnumerable<string>? Organizations { get; set; }
        [FirestoreProperty]
        public DateTime? EstimatedTimeArrival { get; set; }
        [FirestoreProperty]
        public TransportPack TransportPacks { get; set; }

    }
}
