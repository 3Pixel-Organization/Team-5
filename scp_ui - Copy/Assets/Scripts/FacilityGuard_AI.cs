using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FacilityGuard_AI
{
    /// <summary>
    /// Variables Constructor & variables below for Cecking if NPC Is on the ground - if so movement will continue.
    /// </summary>
    public bool IsGrounded;
    public LayerMask Ground;
    public Transform Origin;
    public float Radius;
    public Vector3 Distance;
    public bool Exited;
       
    public FacilityGuard_AI(bool _isgounded,LayerMask layerMask,float _radius,Transform _feet,Vector3 _distance, Vector3 Opposite)
    {
       
        Ground = layerMask;
        Distance = _distance;
        IsGrounded = _isgounded;
        Origin = _feet;
        Radius = _radius;

        _isgounded = Physics2D.OverlapCircle(_feet.position, _radius, layerMask);

        if (_isgounded)
        {
            _feet.position += _distance;
        }
        else if (!_isgounded)
        {
            _feet.position += Opposite;
        }
        
     

    }

   

}
