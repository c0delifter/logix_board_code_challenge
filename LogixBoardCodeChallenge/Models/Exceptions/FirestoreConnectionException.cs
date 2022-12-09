namespace LogixBoardCodeChallenge.Models.Exceptions
{
    public class FirestoreConnectionException : Exception
    {
        public FirestoreConnectionException() { }

        public FirestoreConnectionException(string err)
            : base(string.Format("Cound not perform a Firestore database update for some reason. Error: ", err))
        {

        }
    }
}
