using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastFromCamera : MonoBehaviour
{
    [SerializeField] Camera _camera;
    
    private Ray _ray;
    private RaycastHit _hit;

    private void Update()
    {
        _ray = _camera.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(_ray, out _hit, Mathf.Infinity))
            if (_hit.collider.TryGetComponent(out Cube cube) && Input.GetMouseButtonDown(0))
                cube.Explode();
    }
}
