using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public ShipController _ShipController;
    
    public WindowController _WindowController;
    public CameraController _CameraController;
    public LevelController _LevelController;
    
    private bool _shipShown = false;
    
    void Start()
    {
        _WindowController.OnFirstClick += ShowFirstShip;
        _WindowController.OnSecondClick += ShowSecondShip;
        _WindowController.OnThirdClick += ShowThirdShip;
        _WindowController.OnFourthClick += ShowFourthShip;
        
        _WindowController.OnStartClick += StartFloating;
        _WindowController.OnBackClick += StopFloating;
    }
    

    private void StartFloating()
    {
        if (!_shipShown)
            return;
        
        _WindowController.ShowRiverScreen(() =>
        {
            _ShipController.StartMove();
            
            _ShipController.OnTrigger += ExtendLevel;

        });
    }


    private void StopFloating()
    {
        _WindowController.ShowGarageScreen(() =>
        {
            _ShipController.StopMove();
            _ShipController.PutToStart();
            _CameraController.Reset();
            
            _ShipController.OnTrigger -= ExtendLevel;
            
            _LevelController.ClearLevel();

        });
    }

    private void ExtendLevel()
    {
        _LevelController.AddPiece();
    }

    private void ShowFirstShip() => ShowShip(1);
    private void ShowSecondShip() => ShowShip(2);
    private void ShowThirdShip() => ShowShip(3);
    private void ShowFourthShip() => ShowShip(4);
    
    private void ShowShip(int number)
    {
        var shown = _ShipController.TryShowShip(number);
        
        if (!_shipShown && shown)
        {
            _shipShown = true;
            _CameraController.AllowFollow();
        }
    }
    
}