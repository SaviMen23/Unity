using System.Collections;
using System.Collections.Generic;
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

    private void DestroyCube(Cube cube)
    {
        _spawner.DestroyCube(cube);
        int randomAmountCubes = _spawner.NumberOfCubes;

        for (int i = 0; i < randomAmountCubes; i++)
        {
            if (cube.ChanceOfSeparation >= Random.Range(0f, 1f))
                _spawner.SpawnCubeAfterExplode(cube).CubeDestroy += DestroyCube;
        }

        _exploder.Explode(cube.transform.position);
    }
}
