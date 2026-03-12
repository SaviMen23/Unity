using UnityEngine;

public class Trail : MonoBehaviour
{
    [SerializeField] private Vector3[] _positions;
    [SerializeField] private Target[] _targets;

    private void Start()
    {
        int firstIndex = 0;

        foreach (var target in _targets)
        {
            target.IndexChanged += SetPointForTarget;
            target.Initialize(_positions[firstIndex], firstIndex, _positions.Length);
        }
    }

    private Vector3 SetPointForTarget(int index) =>  _positions[index];
}
