using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;
using System;

public class SceneController : MonoBehaviour
{
    //Scene Management
    const int SCENEINDEX_SPLASH = 0, SCENEINDEX_MAINMENU = 1, SCENEINDEX_OPTIONSMENU = 2, SCENEINDEX_GAME = 3;
    int currentSceneIndex;

    //Splash management
    [Header("Splash Management")]
    [SerializeField] float splashTimeToWait = 1;
    [SerializeField] bool debugDirectToGame = false;    

    //Main Menu management

    //Options Menu management
    [Header("Options Menu")]
    [SerializeField] Slider volumeSlider;
    [SerializeField] Slider difficultySlider;
    [SerializeField] float defaultVolume = 0.8f;

    //Area management
    [Header("Area Management")]    
    [SerializeField] GameObject gameOverCanvas;

    [Header("Debug")]
    [SerializeField] SoundController soundControllerPrefab; //backup sound controller to instatiate, if needed

    [SerializeField] public bool draggingFromButton = false;
    [SerializeField] public bool draggingFromSpawner = false;
    [SerializeField] public bool draggingFromMouse = false;
    [SerializeField] public float touchX, touchY;    
    [SerializeField] public Vector3 buttonOriginalPosition;
    
    SoundController soundController; //expected sound controller
    

    // Start is called before the first frame update
    void Start()
    {
        //kicking off the managers:
        GameManager.Singleton.InitScene(this);
        PlayerManager.Singleton.InitScene(this);
        
        InitScene();

    }

    public void InitScene()
    {
        //starting
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        soundController = FindObjectOfType<SoundController>();

        //auto-detecting sound controller, Instantiating one if needed (then remains)
        if (!soundController)
        {
            Debug.Log("Instantiating Sound controller");
            soundController = Instantiate(soundControllerPrefab);            
            if (!soundController)
                Debug.Log("And still no music player");
        }


        switch (currentSceneIndex)
        {
            case SCENEINDEX_SPLASH:
                if (debugDirectToGame)
                    StartGame();
                else
                    StartCoroutine(InitGame());
                break;

            case SCENEINDEX_MAINMENU:
                soundController.PlayMenuBG();
                break;

            case SCENEINDEX_OPTIONSMENU:
                volumeSlider.value = PlayerManager.GetMasterVolume();                

                soundController.PlayMenuBG();
                break;

            case SCENEINDEX_GAME:
                Debug.Log("init area sceneindex_area");                
                
                gameOverCanvas.SetActive(false);
                FindObjectOfType<LevelController>().LoadArea();
                break;
        }
    }

    #region Splash Scene

    private IEnumerator InitGame()
    {
        yield return new WaitForSeconds(splashTimeToWait);
        //TODO PLACE INITS HERE:


        //---

        LoadMainMenu();
    }

    public void StartGame()
    {

        Debug.Log("Start Game");
        SceneManager.LoadScene(SCENEINDEX_GAME);
    }


    public void LoadMainMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SCENEINDEX_MAINMENU);
    }

    public void LoadOptionsMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SCENEINDEX_OPTIONSMENU);
    }

    #endregion

    #region Main Menu
    public void MainMenuStartGame()
    {
        //for now a bit duplicated, but can have differences
        if (currentSceneIndex == SCENEINDEX_MAINMENU)
        {
            StartGame();
        }
    }

    public void MainMenuQuitGame()
    {
        //for now a bit duplicated, but can have differences
        if (currentSceneIndex == SCENEINDEX_MAINMENU)
        {
            QuitGame();
        }
    }

    #endregion

    #region Options Menu

    public void SetDefaultOptions()
    {
        volumeSlider.value = defaultVolume;        
    }

    public void SaveAndExitOptions()
    {
        PlayerManager.SetMasterVolume(volumeSlider.value);        
        LoadMainMenu();
    }

    #endregion

    void Update()
    {
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;        

        switch (currentSceneIndex)
        {
            case SCENEINDEX_SPLASH:              

                break;

            case SCENEINDEX_MAINMENU:               
  
                break;

            case SCENEINDEX_OPTIONSMENU:
                
                soundController.SetVolume(volumeSlider.value);                                
                break;

            case SCENEINDEX_GAME:
                soundController.PlayGameBG();
                break;
        }
    }

    #region In Game Scene

    public void InGameQuitArea()
    {
        LoadMainMenu();
    }

    public void InGameGameOver()
    {
        gameOverCanvas.SetActive(true);
        Time.timeScale = 0;
    }

    #endregion


    #region Managers and Quit

    public void QuitGame()
    {
        GameManager.Singleton.QuitGame();
    }
    #endregion

    void OnDestroy()
    {
        //Debug.LogError("Destroying SceneManager");
    }
}
