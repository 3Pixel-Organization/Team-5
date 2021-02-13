using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Testing : MonoBehaviour
{
    public SOTileObject obj;
    public BuildingSystem buildingsys;

    public bool startAssigned = false;
    public bool endAssigned = false;
    
    public Vector2Int start;
    public Vector2Int end;

    private void Update() {
        if(Input.GetKeyDown(KeyCode.Alpha1)){
            buildingsys.setCurrentTile(obj);
            Debug.Log("Current Tile :" + buildingsys.getCurrentTile());
        }

        if(Input.GetKeyDown(KeyCode.M)){
            buildingsys.ground.SetTile( new Vector3Int(2,2,0), obj.sprite );
        }

        if(Input.GetKeyDown(KeyCode.Space)){
            
            if(!startAssigned){
                Debug.Log("pos : " + buildingsys.cellPosFromMouse());
                start = buildingsys.cellPosFromMouse();
                startAssigned = true;
                Debug.Log(start);
            }
            else if (!endAssigned){
                end = buildingsys.cellPosFromMouse();
                endAssigned = true;
                buildingsys.buildRoom(start, end);
                startAssigned = false;
                endAssigned = false;
            }

        }

        if(Input.GetKey(KeyCode.F)){

            buildingsys.buildRoom(buildingsys.cellPosFromMouse(), buildingsys.cellPosFromMouse());
        }
    }


}