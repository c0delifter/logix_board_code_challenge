using LogixBoardCodeChallenge.Models;

public interface IFirestoreRepository
{
    Task Add<T>(T entity, CancellationToken ct) where T : FirestoreCollectionItem;
    Task<T> Get<T>(string id, CancellationToken ct) where T : FirestoreCollectionItem;
    Task<IReadOnlyCollection<T>> GetAll<T>(CancellationToken ct) where T : FirestoreCollectionItem;
    Task<IReadOnlyCollection<T>> WhereEqualTo<T>(string fieldPath, object value, CancellationToken ct) where T : FirestoreCollectionItem;
}