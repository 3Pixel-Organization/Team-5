using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingIndicatorController : MonoBehaviour
{
    private TileData _currentTileSprite;
    private SpriteRenderer _spriteRenderer;
    private Vector2 _foregroundOffset = new Vector2(6,3); //Todo create system to find offset on scene load
    private readonly Vector2 centeringOffset = new Vector2(0.5f, 0.5f); 
    private void Awake()
    {
        _spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
    }


    public void SetPosition(Vector2Int givenPosition)
    {
        transform.position = givenPosition+_foregroundOffset+centeringOffset;
    }

    public void SetTile(TileData currentTile)
    {
        _currentTileSprite = currentTile;
        _spriteRenderer.sprite = _currentTileSprite.tileSprite;
    }

    public void EnableIndicator()
    {
        gameObject.SetActive(true);
    }

    public void DisableIndicator()
    {
        gameObject.SetActive(false);

    }

}
