using UnityEngine;

[RequireComponent(typeof(Collider))]

public class Spawner : MonoBehaviour
{
    [SerializeField] private Block _prefab;
    [SerializeField] private Vector3 _scale = new Vector3(1f, 1f, 1f);
    [SerializeField, Min(1)] private int _min = 2;
    [SerializeField, Min(1)] private int _max = 6;

    private Collider _collider;
    private Color[] _colors;
    public int NumberOfCubes => Random.Range(_min, _max + 1);

    private void OnValidate()
    {
        if (_min > _max)
            _min = _max;
    }

    public void Initialize()
    {
        _prefab.transform.localScale = _scale;
        _colors = new Color[] { Color.red, Color.green, Color.cyan };
        _collider = GetComponent<Collider>();
    }

    public Block SpawnStartedCube()
    {
        int divider = 2;
        float maxOffsetX = _collider.bounds.size.x / divider;
        float maxOffsetY = _collider.bounds.size.y / divider;
        float maxOffsetZ = _collider.bounds.size.z / divider;

        Vector3 position = new Vector3(Random.Range(-maxOffsetX, maxOffsetX), Random.Range(-maxOffsetY, maxOffsetY), Random.Range(-maxOffsetZ, maxOffsetZ)) + transform.position;
        float chanceOfSeparation = 1f;

        return SpawnCube(position, _prefab.transform.localScale, chanceOfSeparation);
    }

    private Block SpawnCube(Vector3 position, Vector3 scale, float chanceOfSeparation)
    {
        Block cube = Instantiate(_prefab, position, Quaternion.identity);
        cube.transform.localScale = scale;
        cube.SetChance(chanceOfSeparation);

        if (cube.TryGetComponent(out Renderer renderer))
            renderer.material.color = _colors[Random.Range(0, _colors.Length)];

        return cube;
    }

    public void DestroyCube(Block cube)
    {
        Destroy(cube.gameObject);
    }

    public Block SpawnCubeAfterExplode(Block parentCube)
    {
        int multiplierForChance = 2;
        int multiplierForScale = 2;
        Vector3 position = parentCube.transform.position;
        Block cube = SpawnCube(position, parentCube.transform.localScale / multiplierForScale, parentCube.ChanceOfSeparation / multiplierForChance);

        return cube;
    }
}

