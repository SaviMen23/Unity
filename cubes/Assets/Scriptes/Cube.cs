using System;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Cube : MonoBehaviour
{
    [SerializeField] private float _explosionRadius;
    [SerializeField] private float _explosionForce;

    public event Action<Vector3,float> CubeDestroy;

    private float _chanceOfSeparation;

    public void Explode()
    {
        foreach (Rigidbody explodableObject in GetExplodableObjects())
            explodableObject.AddExplosionForce(_explosionForce,transform.position, _explosionRadius);

        CubeDestroy?.Invoke(transform.localScale / 2, _chanceOfSeparation / 2);
        Destroy(gameObject);
    }

    public void SetChance(float chanceOfSeparation)
    {
        _chanceOfSeparation = chanceOfSeparation;
    }

    private List<Rigidbody> GetExplodableObjects()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, _explosionRadius);
        List<Rigidbody> cubes = new();

        foreach (Collider collider in colliders)
            if(collider.attachedRigidbody != null)
                cubes.Add(collider.attachedRigidbody);
        
        return cubes;
    }
}
