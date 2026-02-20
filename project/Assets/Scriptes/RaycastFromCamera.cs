using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastFromCamera : MonoBehaviour
{
    [SerializeField] ControllerInput _controllerInput;
    [SerializeField] Camera _camera;
    
    private Ray _ray;
    private RaycastHit _hit;

    private void OnEnable()
    {
        _controllerInput.MousePressed += UseRay;
    }

    private void OnDisable()
    {
        _controllerInput.MousePressed -= UseRay;
    }

    private void UseRay()
    {
        _ray = _camera.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(_ray, out _hit, Mathf.Infinity))
            if (_hit.collider.TryGetComponent(out Cube cube))
                cube.Destroy();
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawRay(_ray.origin,_ray.direction* 100f);
    }
}
