using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class ScreenShading : MonoBehaviour
{
    public Image _curtain;
    public float _shadeInTime = 1;
    public float _shadeOutTime = 1;

    float _shadingTime;
    Color _curtainColor;

    void Start()
    {
        _curtain.gameObject.SetActive(false);
    }

    public void Shade(Action onShaded)
    {
        StartCoroutine(ShadeIn(onShaded));
    }
    
    IEnumerator ShadeIn(Action onShaded)
    {
        _shadingTime = _shadeInTime;
        
        _curtain.gameObject.SetActive(true);
        
        while (_shadingTime >= 0)
        {
            _curtainColor.a = 1 - (_shadingTime / _shadeInTime);

            _curtain.color = _curtainColor;
                
            _shadingTime -= Time.deltaTime;

            yield return null;
        }
        
        onShaded?.Invoke();

        StartCoroutine(ShadeOut());
    }
    
    
    IEnumerator ShadeOut()
    {
        _shadingTime = _shadeOutTime;
        
        while (_shadingTime >= 0)
        {
            _curtainColor.a = (_shadingTime / _shadeInTime);

            _curtain.color = _curtainColor;
                
            _shadingTime -= Time.deltaTime;

            yield return null;
        }

        _curtain.gameObject.SetActive(false);
    }
}
