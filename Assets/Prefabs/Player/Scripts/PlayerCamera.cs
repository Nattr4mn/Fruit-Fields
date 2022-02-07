using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    [SerializeField] private bool _isStatic = true;
    [SerializeField] private float _interpolateValue = 0.2f;

    public void Init()
    {
        if (_camera == null)
            _camera = Camera.main;
    }

    public bool TryCameraMove(Vector3 target)
    {
        if (!_isStatic && _camera.transform.position != target)
        {
            var endPosition = target;
            endPosition.z = _camera.transform.position.z;
            _camera.transform.position = Vector3.Lerp(_camera.transform.position, endPosition, _interpolateValue);
            return true;
        }

        return false;
    }
}
