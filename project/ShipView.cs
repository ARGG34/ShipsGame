using System;
using UnityEngine;

public class ShipView : MonoBehaviour
{
    public Vector3 _velocity; 
    
    public Action OnTriggerEncounter;

    public Vector3 GetVelocity() => _velocity;

    private void OnTriggerEnter(Collider other)
    {
        OnTriggerEncounter?.Invoke();
    }

    private void OnDestroy()
    {
        OnTriggerEncounter = null;
    }
}
