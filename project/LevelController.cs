using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class LevelController : MonoBehaviour
{

    public List<Transform> _pieces;

    public Transform _startPiece;
    public Vector3 _displacement;
    public Transform _parent; 

    private List<Transform> _currentPieces;

    private Vector3 _position;
    
    void Awake()
    {
        
    }


    public void AddPiece()
    {
        if (_currentPieces == null)
            _currentPieces = new List<Transform>();
        
        if (_currentPieces.Count == 0)
        {
            _position = _startPiece.position + _displacement;
        }
        else
        {
            _position = _currentPieces[_currentPieces.Count - 1].position + _displacement;
        }
        
        var piecePrefab = GetNextPiece();
        var piece = Instantiate(piecePrefab, _position, Quaternion.identity);
        piece.SetParent(_parent, false);
        
        _currentPieces.Add(piece);
    }


    public void ClearLevel()
    {
        if (_currentPieces == null || _currentPieces.Count == 0)
            return;
        
        for (var i = _currentPieces.Count - 1; i >= 0; i--)
        {
            Destroy(_currentPieces[i].gameObject);
        }
        
        _currentPieces.Clear();
    }

    private int _nextPieceIndex = 0;

    private Transform GetNextPiece()
    {
        var piece = _pieces[_nextPieceIndex];

        _nextPieceIndex++;
        if (_nextPieceIndex >= _pieces.Count)
            _nextPieceIndex = 0;

        return piece;
    }
}
