using Google.Cloud.Firestore;
using LogixBoardCodeChallenge.Models;
using System.Linq;

public class FirestoreRepository : IFirestoreRepository
{
    private readonly FirestoreDb _fireStoreDb;

    public FirestoreRepository(FirestoreDb fireStoreDb)
    {
        _fireStoreDb = fireStoreDb;
    }

    public async Task Add<T>(T entity, CancellationToken ct) where T : FirestoreCollectionItem
    {
        var collection = _fireStoreDb.Collection($"{typeof(T).Name}s");
        await collection.AddAsync(entity);
    }

    public async Task<T> Get<T>(string id, CancellationToken ct) where T : FirestoreCollectionItem
    {
        var document = _fireStoreDb.Collection($"{typeof(T).Name}s").Document(id);
        var snapshot = await document.GetSnapshotAsync(ct);
        return snapshot.ConvertTo<T>();
    }

    public async Task<IReadOnlyCollection<T>> GetAll<T>(CancellationToken ct) where T : FirestoreCollectionItem
    {
        var collection = _fireStoreDb.Collection($"{typeof(T).Name}s");
        var snapshot = await collection.GetSnapshotAsync(ct);
        return snapshot.Documents.Select(x => x.ConvertTo<T>()).ToList();
    }

    public async Task<IReadOnlyCollection<T>> WhereEqualTo<T>(string fieldPath, object value, CancellationToken ct) where T : FirestoreCollectionItem
    {
        return await GetList<T>(_fireStoreDb.Collection($"{typeof(T).Name}s").WhereEqualTo(fieldPath, value), ct);
    }

    private static async Task<IReadOnlyCollection<T>> GetList<T>(Query query, CancellationToken ct) where T : FirestoreCollectionItem
    {
        var snapshot = await query.GetSnapshotAsync(ct);
        return snapshot.Documents.Select(x => x.ConvertTo<T>()).ToList();
    }
}
