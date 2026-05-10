using UnityEngine;

public class EnemyFollow : MonoBehaviour
{
    [SerializeField] private Detect _detect;
    [SerializeField] private float _speed;

    private Transform _target;
    private bool _canMove = false;

    private void OnEnable()
    {
        _detect.EnemySet += SetMoveState;
    }

    private void OnDisable()
    {
        _detect.EnemySet -= SetMoveState;
    }

    public void Renew()
    {
        if (_canMove)
            Move();
    }

    private void SetMoveState(Transform target)
    {
        _target = target;
        _canMove = true;
    }

    private void Move()
    {
        transform.position = Vector3.MoveTowards(transform.position, _target.position, _speed * Time.deltaTime);
    }
}
