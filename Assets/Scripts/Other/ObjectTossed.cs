using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectTossed : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rigidbody;
    [SerializeField] private float _dropForce;

    public void Toss()
    {
        _rigidbody.velocity = Vector2.up * _dropForce;
    }
}
