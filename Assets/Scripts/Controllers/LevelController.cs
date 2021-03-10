
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class LevelController : MonoBehaviour
{
    
    //handle to sceneController
    SceneController sceneController;

    //Board management
    //[Tooltip("Area board size")]
    [SerializeField] public int boardSizeX = 5;
    [SerializeField] public int boardSizeY = 6;

    //Area game elements
    [Header("Main Game Elements")]
    [Tooltip("Area initial Credits")]
    [SerializeField] public int credits = 500;

    [Header("Area Audio Clips")]
    [SerializeField] public AudioClip buildAudioClip;
    [SerializeField] public AudioClip gameOverAudioClip;

    //Runtime variables
    [Header("Runtime variables")]
    [Tooltip("Area time in Seconds")]    
    [SerializeField] public float areaTime = 10.0f;
    [SerializeField] public float currentAreaTime = 0.0f; //TODO remove serialize field

    [SerializeField] public float areaStartTime;  //TODO Remove serializefiel
    [SerializeField] public bool areaTimeout = false; //TODO remove serialize field
    [SerializeField] public bool lostGame = false;

    
    public void Start()
    {
        InitScene(FindObjectOfType<SceneController>());
    }
    public void InitScene(SceneController _sceneController)
    {
        this.sceneController = _sceneController;               

        //load first Area:
        LoadArea();
    }

    public void LoadArea()
    {        

        areaStartTime = Time.time;       
        currentAreaTime = 0;
        areaTimeout = false;        
        lostGame = false;
       
    }
    

    public void Update()
    {
        UpdateAreaTime();
        
        
    }


 
    private void LostGame()
    {
        Debug.Log("Lost Game!");
        var audioSource = GetComponent<AudioSource>();

        audioSource.clip = gameOverAudioClip;
        audioSource.Play();        
        sceneController.InGameGameOver();

    }

    #region Credit Management

    public int GetCredits()
    {
        return credits;
    }

    public void AddCredits(int quantity)
    {
        credits += quantity;
    }

    public void SpendCredits(int quantity)
    {
        if (credits >= quantity)
            credits -= quantity;
    }

    public bool EnoughCredits(int quantity)
    {
        return credits >= quantity;
    }

    #endregion

    #region area time management

    private void UpdateAreaTime()
    {
        SetCurrentAreaTime(Time.time - areaStartTime);
    }

    public float GetCurrentAreaTime()
    {
        return currentAreaTime;
    }

    public void SetCurrentAreaTime(float _currentAreaTime)
    {
        currentAreaTime = _currentAreaTime;     
    }

    public float GetCurrentAreaTimeRatio()
    {
        return currentAreaTime / areaTime;
    }

    #endregion


    #region AUX

    //AUX Functions
    public bool IsInsideBoard(Vector2 gridPos)
    {
        return (gridPos.x >= 1 && gridPos.y >= 1 && gridPos.x <= boardSizeX && gridPos.y <= boardSizeY);
    }

    #endregion

    public void QuitGame()
    {

    }

    void OnDestroy()
    {
        //Debug.LogError("Destroying AreaManager");
    }
}


