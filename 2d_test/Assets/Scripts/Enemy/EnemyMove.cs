using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    [SerializeField] private Detect _detect;
    [SerializeField] private float _speed;

    private Transform _target;

    private void OnEnable()
    {
        _detect.EnemySet += SetMoveState;
    }

    private void OnDisable()
    {
        _detect.EnemySet -= SetMoveState;
    }
    
    private void SetMoveState(Transform target)
    {
        _target = target;
    }

    public void Move()
    {
        if (_target != null)
            transform.position = Vector3.MoveTowards(transform.position, _target.position, _speed * Time.deltaTime);
    }
}
