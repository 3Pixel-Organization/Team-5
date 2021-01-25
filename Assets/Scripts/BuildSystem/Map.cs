using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map
{

    public Vector2Int origin;
    public int width;
    public int height;
    public float cellSize;

    public Map(Vector2Int origin, int width, int height, float cellSize){
        this.origin = origin;
        this.width = width;
        this.height = height;
        this.cellSize = cellSize;
        DisplayMap();
    }

    void DisplayMap(){

        for(int x = 0; x < width; x++){
            for(int y = 0; y < height; y++){
                Debug.DrawLine((new Vector2(x, y) * cellSize + origin), (new Vector2(x, y+1) * cellSize + origin), Color.white, 100f);
                Debug.DrawLine((new Vector2(x, y) * cellSize + origin), (new Vector2(x+1, y) * cellSize + origin), Color.white, 100f);
            }
        }

        Debug.DrawLine((new Vector2(width, 0) * cellSize + origin), (new Vector2(width, height) * cellSize + origin), Color.white, 100f);
        Debug.DrawLine((new Vector2(0, height) * cellSize + origin), (new Vector2(width, height) * cellSize + origin), Color.white, 100f);
    }



}
