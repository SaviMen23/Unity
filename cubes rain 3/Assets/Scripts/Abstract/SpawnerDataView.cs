using UnityEngine;
using TMPro;

public abstract class SpawnerDataView<T> : MonoBehaviour where T : Component
{
    [SerializeField] protected Spawner<T> _spawner;
    [SerializeField] protected Pool<T> _pool;
    [SerializeField] protected TextMeshProUGUI _text;

    protected int _numberOfSpawnedObjects = 0;
    protected int _numberOfActiveObjects = 0;
    protected int _numberOfCreateObjects = 0;
    
    protected void Update()
    {
        Show();
    }

    protected void OnEnable()
    {
        _spawner.ObjectSpawned += ChangeNumberOfSpawned;
        _pool.PoolExpand += ChangeNumberOfCreated;
        _pool.NumberOfActiveChange += ChangeNumberOfActive;
    }

    protected void OnDisable()
    {
        _spawner.ObjectSpawned -= ChangeNumberOfSpawned;
        _pool.PoolExpand -= ChangeNumberOfCreated;
        _pool.NumberOfActiveChange -= ChangeNumberOfActive;
    }

    protected void ChangeNumberOfSpawned(int numberOfSpawned)
    {
        _numberOfSpawnedObjects = numberOfSpawned;
    }

    protected void ChangeNumberOfActive(int numberOfActive)
    {
        _numberOfActiveObjects = numberOfActive;
    }

    protected void ChangeNumberOfCreated(int created)
    {
        _numberOfCreateObjects = created;
    }

    protected void Show()
    {
        _text.SetText($"all spawned objects in {gameObject.name}: {_numberOfSpawnedObjects}\n" +
            $"all created objects in {gameObject.name}: {_numberOfCreateObjects}\n" +
            $"active objects in {gameObject.name}: {_numberOfActiveObjects}");
    }
}