
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LevelController : MonoBehaviour
{
    
    //handle to sceneController
    SceneController sceneController;


    //Area game elements
    [Header("Main Game Elements")]
    [Tooltip("Area initial Credits")]    
    [SerializeField] TMP_Text creditsText;

    [Header("Game Audio Clips")]
    [SerializeField] public AudioClip buildAudioClip;
    [SerializeField] public AudioClip gameOverAudioClip;

    //Runtime variables
    [Header("Runtime variables")]    
    [SerializeField] TMP_Text levelTimeText;    
    [SerializeField] public float currentLevelTime = 0.0f; //TODO remove serialize field

    [SerializeField] public float levelStartTime;  //TODO Remove serializefiel    
    [SerializeField] public bool lostGame = false;

    [SerializeField] bool buildButtonPressed = false;    
    
    public void Start()
    {
        InitScene(FindObjectOfType<SceneController>());
    }
    public void InitScene(SceneController _sceneController)
    {
        this.sceneController = _sceneController;               

        //load first Area:
        LoadLevel();
    }

    public void LoadLevel()
    {        

        levelStartTime = Time.time;       
        currentLevelTime = 0;              
        lostGame = false;
       
    }
    

    public void Update()
    {
        UpdateLevelTime();
        UpdateLevelTimeText();        
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

    public void UpdateCreditsText(int credits)
    {
        creditsText.text = credits.ToString();
    }

    #endregion

    #region level time management

    private void UpdateLevelTime()
    {
        SetCurrentLevelTime(Time.time - levelStartTime);
    }

    private void UpdateLevelTimeText()
    {
        levelTimeText.text = Mathf.FloorToInt(currentLevelTime).ToString();
    }

    public float GetCurrentLevelTime()
    {
        return currentLevelTime;
    }

    public void SetCurrentLevelTime(float _currentLevelTime)
    {
        currentLevelTime = _currentLevelTime;     
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


