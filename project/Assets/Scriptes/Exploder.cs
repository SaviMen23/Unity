using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exploder : MonoBehaviour
{
    [SerializeField] private float _radius;
    [SerializeField] private float _force;

    public void Explode(Vector3 position)
    {
        foreach (Rigidbody explodableCube in GetExplodableCubes())
            explodableCube.AddExplosionForce(_force,position,_radius);
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
