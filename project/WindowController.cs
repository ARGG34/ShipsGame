using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class WindowController : MonoBehaviour
{
    public ScreenShading _screenShading;

    public GarageWindowController _GarageWindowController;

    public event Action OnStartClick;
    public event Action OnBackClick;
    public event Action OnFirstClick;
    public event Action OnSecondClick;
    public event Action OnThirdClick;
    public event Action OnFourthClick;


    // Start is called before the first frame update
    void Start()
    {
        _GarageWindowController.OnFirstClick += FirstButtonClick;
        _GarageWindowController.OnSecondClick += SecondButtonClick;
        _GarageWindowController.OnThirdClick += ThirdButtonClick;
        _GarageWindowController.OnFourthClick += FourthButtonClick;
        
        _GarageWindowController.OnStartClick += StartClick;
        _GarageWindowController.OnBackClick += BackClick;
    }

    public void ShowGarageScreen(Action onHidden)
    {
        _screenShading.Shade(() =>
        {
            _GarageWindowController.ShowGarageButtons(true);
            _GarageWindowController.ShowRiverButtons(false);
            
            onHidden?.Invoke();
        });
    }

    public void ShowRiverScreen(Action onHidden)
    {
        _screenShading.Shade(() =>
        {
            _GarageWindowController.ShowGarageButtons(false);
            _GarageWindowController.ShowRiverButtons(true);
            
            onHidden?.Invoke();
            
        });
    }

   

    private void StartClick()
    {
        OnStartClick?.Invoke();
    }
    
    private void BackClick()
    {
        OnBackClick?.Invoke();
    }

    private void FirstButtonClick()
    {
        OnFirstClick?.Invoke();
    }
    
    private void SecondButtonClick()
    {
        OnSecondClick?.Invoke();
    }
    
    private void ThirdButtonClick()
    {
        OnThirdClick?.Invoke();
    }
    
    private void FourthButtonClick()
    {
        OnFourthClick?.Invoke();
    }
    
}