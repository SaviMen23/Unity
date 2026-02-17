using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Cube _prefab;
    [SerializeField, Min(1)] private int _min = 2;
    [SerializeField, Min(1)] private int _max = 6;

    private Collider _collider; 
    private Color[] _colors;

    private void OnValidate()
    {
        if (_min > _max)
            _min = _max;
    }

    private void Start()
    {
        _colors = new Color[] { Color.red, Color.green, Color.cyan };
        _collider = GetComponent<Collider>();
        Spawn(new Vector3(2f,2f,2f), 1f);
    }

    private void Spawn(Vector3 scale, float chanceOfSeparation)
    {
        int numberOfCubes = Random.Range(_min, _max + 1);
        float maxOffsetX = _collider.bounds.size.x / 2;
        float maxOffsetY = _collider.bounds.size.y / 2;
        float maxOffsetZ = _collider.bounds.size.z / 2;

        for (int i = 0; i < numberOfCubes; i++)
        {
            if (chanceOfSeparation >= Random.Range(0f, 1f))
            {
                Vector3 position = new Vector3(Random.Range(-maxOffsetX, maxOffsetX), Random.Range(-maxOffsetY, maxOffsetY), Random.Range(-maxOffsetZ, maxOffsetZ)) + transform.position;
                Cube currentCube = Instantiate(_prefab, position, Quaternion.identity);
                currentCube.transform.localScale = scale;
                currentCube.GetComponent<Renderer>().material.color = _colors[Random.Range(0, _colors.Length)];
                currentCube.SetChance(chanceOfSeparation);
                currentCube.CubeDestroy += Spawn;
            }
        }
    }
}

