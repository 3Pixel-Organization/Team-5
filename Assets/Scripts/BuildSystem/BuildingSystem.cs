using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class BuildingSystem : MonoBehaviour
{
    
/*

    
    #region Singleton
    [SerializeField] private static BuildingSystem INSTANCE = null;
    private BuildingSystem(){

    }

    private static void createInstance(){
        if(INSTANCE == null){
            Debug.Log("No instance of BuildingSystem Available");
            INSTANCE = new BuildingSystem();
        }
    }

    private static BuildingSystem getInstance(){
        if(INSTANCE == null) createInstance();
        
        return INSTANCE;
    }


    #endregion


*/


    public Map map;
    public int width, height;
    public Vector2Int origin;


    // Building mode variables
    public Tilemap ground;
    public Tilemap walls;
    public Tilemap doors;

    public KeyCode buildingModeKey = KeyCode.C;
    private SOTileObject currentTile; // this tile is the one you are gonna draw on the screen.
    private bool buildingMode = false;
 


    //Highlight variables
    public Tile highlightTile;
    public Tilemap highlightMap;

    private Vector3Int previous;
    private Tile highlightTileValue;


    private void Start() {
        map = new Map(origin, width, height, GetComponent<UnityEngine.Grid>().cellSize.x);
        highlightTileValue = highlightTile;
    }
 




    #region COPY PASTE OF SOME CODE FROM GOOGLE LOL

    // do late so that the player has a chance to move in update if necessary
    private void Update()
    {

        HighlightTileMouse();


        //Building Mode
        if(Input.GetKeyDown(buildingModeKey)){
            onBuildingModeClick();
        }
        
    }

    #endregion


    #region Highlight

    public void HighlightTileMouse(){
        Vector3Int MousePos = getCellFromMousePos();
        Vector3Int currentCell = WorldToCell(MousePos, highlightMap);

        if(currentCell != previous)
        {
            // set the new tile
            highlightMap.SetTile(currentCell, highlightTile);
 
            // erase previous
            highlightMap.SetTile(previous, null);
 
            // save the new position for next frame
            previous = currentCell;
        }
    }


    #endregion



    #region BuildingSystem

    public void onBuildingModeClick(){ 
        //turn building mode on/off
        //can be called by a button from the ui or by clicking on the building mode keybind
        buildingMode = !buildingMode;
        if(buildingMode){
            startBuildingMode();
        }
        else{
            endBuildingMode();
        }
    }
    
    public void startBuildingMode(){
        //open the UI related to Building mode.
    }

    public void endBuildingMode(){
        //if the player is doing something while leaving the mode stop it and return false to it.

        //close building mode UI.



        currentTile = null;
        highlightTile = highlightTileValue;

    }

    
    public bool setCurrentTile(SOTileObject t){
        //this fonction is called by buttons in the UI.
        if(enoughRess(t)){
            currentTile = t;
            highlightTile = t.sprite;
            return true;
        }
        return false;
    }
    public SOTileObject getCurrentTile(){
        return currentTile;
    }

    public Tilemap getTileMapCurrentTile(){
        switch(currentTile.getGridAppartenance()){
            case SOTileObject.ObjectType.ground:
                return ground;

            case SOTileObject.ObjectType.wall:
                return walls;

            case SOTileObject.ObjectType.door:
                return doors;
        }
        return null;
    }

    
    public void buildRoom(Vector2Int startPos, Vector2Int endPos){
        //this function is called ONLY when the player confirm the build
        if(currentTile == null) return;

        //we want to build the room from its top left corner to make the for loop easier. 
        //However the start point may not always be the top left corner so we reorganize the values by min max. the top left corner has for coordonate: (minX, minY).

        int startX = Mathf.Min(startPos.x, endPos.x);
        int startY = Mathf.Min(startPos.y, endPos.y);

        int endX = Mathf.Max(startPos.x, endPos.x);
        int endY = Mathf.Max(startPos.y, endPos.y);


        for (int i = startX ; i < endX ; i++){
            Vector2Int vec = new Vector2Int(i, startY);
            Debug.Log("pos ${vec}" + buildBlock(new Vector2Int(i, startY)));
            Debug.Log("current Tile : " + currentTile);
            buildBlock(new Vector2Int(i, endY));
        }

        for (int i = startY ; i < endY ; i++){
            buildBlock(new Vector2Int(startX, i));
            buildBlock(new Vector2Int(endX, i));
        }

        buildBlock(new Vector2Int(endX, endY));



    }

    //HELPER FUNCTIONS

    public bool canBuildPos(Vector2Int pos, Tilemap map){
        //This function checks if the position given is taken (so you cant build on it) and if it is return false, otherwise return true


        if(currentTile == null) return true;
        if(map.GetTile( (Vector3Int) pos) != null) return false;
        
        Debug.Log("BLABLABLA " + map.GetTile( (Vector3Int) pos));

        return true;
    }

    public bool enoughRess(SOTileObject tile){
        //This function checks if the player has enough ressources to build the given building and he does return true, otherwise return false
        
        if(currentTile == null) return true;
        //check ressources of player to see if you got enough to build the block with tile.ressources;
        
        return true;
    }

    public bool buildBlock(Vector2Int pos){
        //this function build the currentTile at this position (tile map pos)
        if(currentTile == null){
            Debug.Log("bite");
            return false;
        }

        if(!enoughRess(currentTile)){
            Debug.Log("bite2");
            return false;
        }

        switch(currentTile.getGridAppartenance()){
            case SOTileObject.ObjectType.ground:
                if(!canBuildPos(pos, ground)) return false;
                ground.SetTile((Vector3Int) pos, currentTile.sprite);
            break;

            case SOTileObject.ObjectType.wall:
                if(!canBuildPos(pos, ground)) return false;
                walls.SetTile((Vector3Int) pos, currentTile.sprite);
            break;

            case SOTileObject.ObjectType.door:
                if(!canBuildPos(pos, ground)) return false;
                doors.SetTile((Vector3Int) pos, currentTile.sprite);
            break;

            default:
                Debug.Log("default");
                return false;
        }
        Debug.Log("bite3");
        return true;
    }

    public bool destroyBlock(Vector2Int pos){
        //this function build the currentTile at this position (tile map pos)
        if(doors.GetTile((Vector3Int) pos) != null){
            doors.SetTile((Vector3Int) pos, null);
            return true;
        }
        else if(walls.GetTile((Vector3Int) pos) != null){
            walls.SetTile((Vector3Int) pos, null);
            return true;
        }        
        else if(ground.GetTile((Vector3Int) pos) != null){
            ground.SetTile((Vector3Int) pos, null);
            return true;
        }
        return false;
    }

    #endregion


































    #region TGRID CODE STOLEN LOL

    public Vector3Int getCellFromMousePos(){
        return GetCell(GetMouseWorldPos());
    }

    public Vector3Int WorldToCell(Vector3Int MousePos, Tilemap tilemap){
        return tilemap.WorldToCell(MousePos) + (Vector3Int) origin;
    }

    public Vector2Int cellPosFromMouse(){
        Vector3Int MousePos = getCellFromMousePos();
        Vector3Int currentCell = WorldToCell(MousePos, highlightMap);
        return (Vector2Int) currentCell;
    }


    public Vector3Int GetCell(Vector2 worldPosition)
    {
        Vector3Int res = new Vector3Int();
        res.x = Mathf.FloorToInt((worldPosition - map.origin).x / map.cellSize);
        res.y = Mathf.FloorToInt((worldPosition - map.origin).y / map.cellSize);
        
        //In the case we are trying to get a cell that doesnt exist in our grind it will return the closest one on the border of the grid instead of throwing an error.
        res.x = Mathf.Clamp(res.x, 0, width-1);
        res.y = Mathf.Clamp(res.y, 0, height-1);

        return res;
    }

    public static Vector3 GetMouseWorldPos()
    //This function returns the mouse positon in the world
    {
        Camera worldCam = Camera.main;
        Vector3 screenPos = Input.mousePosition;
        Vector3 worldPosistion = worldCam.ScreenToWorldPoint(screenPos);
        worldPosistion.z = 0f;
        return worldPosistion;
    }

    #endregion
}
