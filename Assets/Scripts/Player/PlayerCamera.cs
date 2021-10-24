using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    [SerializeField] private bool _isStatic = true;
    [SerializeField] private Transform _target;
    [SerializeField] private float _interpolateValue = 0.2f;


    void FixedUpdate()
    {
        if (!_isStatic && transform.position != _target.position)
        {
            var endPosition = _target.position;
            endPosition.z = transform.position.z;
            transform.position = Vector3.Lerp(transform.position, endPosition, _interpolateValue);
        }
    }
}
