using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipMovement : MonoBehaviour
{
    
    private Transform _transform;
    private Vector3 _position;
    private Vector3 _velocity;
    private bool _moving;
    
    private void Awake()
    {
        _transform = transform;
    }

    public void SetVelocity(Vector3 velocity)
    {
        _velocity = velocity;
    }

    public void Move(bool move)
    {
        _moving = move;
    }

    // Update is called once per frame
    private void Update()
    {
        if (!_moving) return;

        _position = _transform.position;
        _position += _velocity * Time.deltaTime;
        _transform.position = _position;
    }
}
