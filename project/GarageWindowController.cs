using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class GarageWindowController : MonoBehaviour
{

    public Button _buttonFirst;
    public Button _buttonSecond;
    public Button _buttonThird;
    public Button _buttonFourth;
    public Button _buttonStart;

    public RectTransform _selected;
    
    public Button _buttonBack;
    
    public Action OnBackClick;

    public Action OnFirstClick;
    public Action OnSecondClick;
    public Action OnThirdClick;
    public Action OnFourthClick;
    public Action OnStartClick;
    
    
    void Start()
    {
        _buttonFirst.onClick.AddListener(FirstButtonClick);
        _buttonSecond.onClick.AddListener(SecondButtonClick);
        _buttonThird.onClick.AddListener(ThirdButtonClick);
        _buttonFourth.onClick.AddListener(FourthButtonClick);
        
        _buttonStart.onClick.AddListener(StartClick);
        
        _buttonBack.onClick.AddListener(BackClick);
        
        _selected.gameObject.SetActive(false);
        _buttonBack.gameObject.SetActive(false);
    }
    
    public void ShowGarageButtons(bool show)
    {
        _buttonFirst.gameObject.SetActive(show);
        _buttonSecond.gameObject.SetActive(show);
        _buttonThird.gameObject.SetActive(show);
        _buttonFourth.gameObject.SetActive(show);
        _buttonStart.gameObject.SetActive(show);
        
        _selected.gameObject.SetActive(show);
    }
    
    public void ShowRiverButtons(bool show)
    {
        _buttonBack.gameObject.SetActive(show);
    }
    

    private void StartClick()
    {
        OnStartClick?.Invoke();
    }

    private void FirstButtonClick()
    {
        OnFirstClick?.Invoke();
        SelectButton(_buttonFirst.transform.position);
    }
    
    private void SecondButtonClick()
    {
        OnSecondClick?.Invoke();
        SelectButton(_buttonSecond.transform.position);
    }
    
    private void ThirdButtonClick()
    {
        OnThirdClick?.Invoke();
        SelectButton(_buttonThird.transform.position);
    }
    
    private void FourthButtonClick()
    {
        OnFourthClick?.Invoke();
        SelectButton(_buttonFourth.transform.position);
    }

    private void SelectButton(Vector3 position)
    {
        if (!_selected.gameObject.activeSelf)
            _selected.gameObject.SetActive(true);
        
        _selected.position = position;
    }
    
    private void BackClick()
    {
        OnBackClick?.Invoke();
    }
}