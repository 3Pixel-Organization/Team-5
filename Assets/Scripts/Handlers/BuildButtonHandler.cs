using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuildButtonHandler : MonoBehaviour
{
    public TileData tileData;

    private Button button;    
    private BuildController buildController;
    private LevelController levelController;

    // Start is called before the first frame update
    void Start()
    {
        buildController = FindObjectOfType<BuildController>();
        levelController = FindObjectOfType<LevelController>();

        if (!tileData)
        {
            Debug.LogError("Tile Data Missing From Button");
        }

        button = GetComponent<Button>();

        reloadTileData();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void reloadTileData()
    {
        button.image.sprite = tileData.tileSprite;
        Debug.Log("changed tile data");
    }

    public void SetSelectedTile()
    {
        buildController.SetSelectedTile(tileData); //calling to inform buildcontroller
        levelController.SetSelectedTile(tileData); //calling to inform for UI change

    }
}
