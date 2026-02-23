using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exploder : MonoBehaviour
{
    [SerializeField] private float _radius;
    [SerializeField] private float _force;

    public void Explode(Block cube)
    {
        float factor = 1f/ cube.ChanceOfSeparation;

        foreach (Rigidbody explodableCube in GetExplodableCubes())
            explodableCube.AddExplosionForce(_force * factor, cube.transform.position, _radius * factor);
    }

    private List<Rigidbody> GetExplodableCubes()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, _radius);
        List<Rigidbody> cubes = new();

        foreach(Collider collider in colliders)
            if(collider.attachedRigidbody != null)
                cubes.Add(collider.attachedRigidbody);

        return cubes;
    }
}   
