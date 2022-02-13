using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    [SerializeField] private bool _isStatic = true;
    [SerializeField] private float _interpolateValue = 0.2f;
    [Header("Camera installation boundaries")]
    [SerializeField] private Transform _minPoint;
    [SerializeField] private Transform _maxPoint;

    public void Init()
    {
        if (_camera == null)
            _camera = Camera.main;
    }

    public bool TryCameraMove(Vector3 target)
    {
        
        if(!_isStatic && _minPoint != null && _maxPoint != null)
        {
            var cameraSize = _camera.ScreenToWorldPoint(new Vector2(_camera.pixelWidth, _camera.pixelHeight)) - _camera.ScreenToWorldPoint(new Vector2(0, 0));
            var endPosition = target;
            endPosition.z = _camera.transform.position.z;

            if (target.x - cameraSize.x / 2 <= _minPoint.position.x)
            {
                endPosition.x = _minPoint.position.x + cameraSize.x / 2;
            }
            else if(target.x + cameraSize.x / 2 >= _maxPoint.position.x)
            {
                endPosition.x = _maxPoint.position.x - cameraSize.x / 2;
            }


            if (target.y - cameraSize.y / 2 <= _minPoint.position.y)
            {
                endPosition.y = _minPoint.position.y + cameraSize.y / 2;
            }
            else if (target.y + cameraSize.y / 2 >= _maxPoint.position.y)
            {
                endPosition.y = _maxPoint.position.y - cameraSize.y / 2;
            }

            _camera.transform.position = Vector3.Lerp(_camera.transform.position, endPosition, _interpolateValue * Time.deltaTime);
            return true;
        }

        return false;
    }
}
