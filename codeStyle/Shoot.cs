using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Shoot : MonoBehaviour
{
    [SerializeField] public float _speed;
    [SerializeField] GameObject _prefab;
    [SerializeField] float _delayShoot;
    [SerializeField] private Transform _targetToShoot;

    private void Start()
    {
        StartCoroutine(ShootingWorker());
    }

    private IEnumerator ShootingWorker()
    {
        WaitForSeconds delay = new WaitForSeconds(_delayShoot);
        bool isWork = enabled;

        while (isWork)
        {
            Vector3 direction = (_targetToShoot.position - transform.position).normalized;
            GameObject NewBullet = Instantiate(_prefab, transform.position + direction, Quaternion.identity);

            NewBullet.GetComponent<Rigidbody>().transform.up = direction;
            NewBullet.GetComponent<Rigidbody>().velocity = direction * _speed;

            yield return delay;
        }
    }
}