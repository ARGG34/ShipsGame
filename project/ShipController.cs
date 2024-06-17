using UnityEngine;
using System;
using System.Collections.Generic;

public class ShipController : MonoBehaviour
{
   public ShipIdle _Idle;
   public ShipMovement _Movement;

   public List<ShipView> _ships;

   public Action OnTrigger;
   
   
   private Transform _transform;

   private ShipView _currentShip;

   private Vector3 _startPoint;

   void Awake()
   {
      _transform = transform;
      _startPoint = _transform.position;
   }

   public bool TryShowShip(int number)
   {
      var shipNumber = number - 1;
      
      if (shipNumber < 0 || shipNumber >= _ships.Count)
      {
         Debug.Log("no such ship");
         return false;
      }

      TryDestroyShip(_currentShip);

      _currentShip = Instantiate(_ships[shipNumber]);
      _currentShip.transform.SetParent(_transform, false);

      _currentShip.OnTriggerEncounter += OnEncounter;
      
      return true;
   }
   

   public void StartMove()
   {
      _Movement.SetVelocity(_currentShip.GetVelocity());
      _Movement.Move(true);
   }

   public void StopMove()
   {
      _Movement.Move(false);
   }


   public void Put(Vector3 position) => _transform.position = position;

   public void PutToStart()
   {
      Put(_startPoint);
   }

   public Transform GetTransform() => _transform;


   private void OnEncounter() => OnTrigger?.Invoke();


   private void TryDestroyShip(ShipView view)
   {
      if (view == null)
         return;
      
      _currentShip.OnTriggerEncounter -= OnEncounter;
      
      Destroy(view.gameObject);
   }


}
