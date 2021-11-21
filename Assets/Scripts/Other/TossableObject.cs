using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class TossableObject : MonoBehaviour
{
    [SerializeField] private float _tossForce;
    private Rigidbody2D _rigidbody;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    public void Toss()
    {
        _rigidbody.velocity = Vector2.up * _tossForce;
    }
}
