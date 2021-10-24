using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thrown : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rigidbody;
    [SerializeField] private float _dropForce;

    public void Throw()
    {
        _rigidbody.velocity += Vector2.up * _dropForce;
    }
}
