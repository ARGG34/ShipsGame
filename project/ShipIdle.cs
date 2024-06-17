using System.Collections;
using UnityEngine;

public class ShipIdle : MonoBehaviour
{

    public float _floatTime = 2f;
    public float _floatSpeed;

    private Vector3 _position;
    private Vector3 _initialPosition;
    private bool _floatUp = true;
    private float _currentTime = 0;

    private void Awake()
    {
        _initialPosition = transform.position;
    }
    

    public void OnEnable()
    {
        transform.position = _initialPosition;
        _currentTime = 0;

        StartCoroutine(Floating());
    }

    public void OnDisable()
    {
        StopAllCoroutines();
    }

    private IEnumerator Floating()
    {
        while (true)
        {
            _position = transform.position;

            if (_floatUp)
                _position.y += _floatSpeed * Time.deltaTime;
            else
                _position.y -= _floatSpeed * Time.deltaTime;

            _currentTime += Time.deltaTime;

            if (_currentTime >= _floatTime)
            {
                _floatUp = !_floatUp;
                _currentTime = 0;
            }
            
            transform.position = _position;

            yield return null;
        }
    }
}