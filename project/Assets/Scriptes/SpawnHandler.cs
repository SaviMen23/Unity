using UnityEngine;

public class SpawnHandler : MonoBehaviour
{
    [SerializeField] private Spawner _spawner;
    [SerializeField] private Exploder _exploder;

    public void FirstSpawn()
    {
        int randomAmountCubes = _spawner.NumberOfCubes;

        for (int i = 0; i < randomAmountCubes; i++)
            _spawner.SpawnStartedCube().CubeDestroy += DestroyCube;
    }

    private void DestroyCube(Block cube)
    {
        _spawner.DestroyCube(cube);
        int randomAmountCubes = _spawner.NumberOfCubes;
        bool isDivided = false;

        for (int i = 0; i < randomAmountCubes; i++)
        {
            if (cube.ChanceOfSeparation >= Random.Range(0f, 1f))
            {
                isDivided = true;
                _spawner.SpawnCubeAfterExplode(cube).CubeDestroy += DestroyCube;
            }
        }

        if (isDivided == false)
            _exploder.Explode(cube);
    }
}
