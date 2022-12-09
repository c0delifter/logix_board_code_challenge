using Google.Cloud.Firestore;

namespace LogixBoardCodeChallenge.Models
{
    [FirestoreData]
    public class Organization : FirestoreCollectionItem
    {
        [FirestoreProperty]
        public string? Id { get; set; }
        [FirestoreProperty]
        public string Type { get; set; } = "ORGANIZATION";
        [FirestoreProperty]
        public string? Code { get; set; }
    }
}
