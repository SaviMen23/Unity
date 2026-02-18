using UnityEngine;

[RequireComponent(typeof(Collider))]

public class Spawner : MonoBehaviour
{
    [SerializeField] private Cube _prefab;
    [SerializeField] private Exploder _exploder;
    [SerializeField] private Vector3 _scale = new Vector3(1f, 1f, 1f);
    [SerializeField, Min(1)] private int _min = 2;
    [SerializeField, Min(1)] private int _max = 6;

    private Collider _collider;
    private Color[] _colors;
    private int NumberOfCubes => Random.Range(_min, _max + 1);

    private void OnValidate()
    {
        if (_min > _max)
            _min = _max;
    }

    private void Start()
    {
        _prefab.transform.localScale = _scale;
        _colors = new Color[] { Color.red, Color.green, Color.cyan };
        _collider = GetComponent<Collider>();
        FirstSpawn();
    }

    private void FirstSpawn()
    {
        float maxOffsetX = _collider.bounds.size.x / 2;
        float maxOffsetY = _collider.bounds.size.y / 2;
        float maxOffsetZ = _collider.bounds.size.z / 2;

        for (int i = 0; i < NumberOfCubes; i++)
        {
            Vector3 position = new Vector3(Random.Range(-maxOffsetX, maxOffsetX), Random.Range(-maxOffsetY, maxOffsetY), Random.Range(-maxOffsetZ, maxOffsetZ)) + transform.position;
            SpawnCube(position, _prefab.transform.localScale, 1f);
        }
    }

    private void SpawnCube(Vector3 position, Vector3 scale, float chanceOfSeparation)
    {
        if (chanceOfSeparation > Random.Range(0f, 1f))
        {
            Cube cube = Instantiate(_prefab, position, Quaternion.identity);
            cube.transform.localScale = scale;
            cube.SetChance(chanceOfSeparation);
            cube.CubeDestroy += CubeDestroy;

            if (cube.TryGetComponent(out Renderer renderer))
                renderer.material.color = _colors[Random.Range(0, _colors.Length)];
        }
    }

    private void CubeDestroy(Cube cube)
    {
        SpawnAfterExlode(cube);
        Destroy(cube.gameObject);
    }

    private void SpawnAfterExlode(Cube parentCube)
    {
        int multiplierForChance = 2;
        int multiplierForScale = 2;

        for (int i = 0; i < NumberOfCubes; i++)
        {
            Vector3 position = parentCube.transform.position;
            SpawnCube(position, parentCube.transform.localScale / multiplierForScale, parentCube.ChanceOfSeparation / multiplierForChance);
        }
        _exploder.Explode(parentCube.transform.position);
    }
}

