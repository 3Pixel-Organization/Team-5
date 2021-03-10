using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundController : MonoBehaviour
{
    [SerializeField] AudioClip menuBGAudioClip;
    [SerializeField] AudioClip gameBGAudioClip;
    AudioSource audioSource;

    public enum BGMusicState { NotPlaying = 0, PlayingMenuBG, PlayingGameBG }
    public BGMusicState bgMusicState { get; set; }

    //TODO add attribution for music:
    /*

        Time by Mike Leite | https://soundcloud.com/mikeleite
        Music promoted by https://www.free-stock-music.com
        Creative Commons Attribution 3.0 Unported License
        https://creativecommons.org/licenses/by/3.0/deed.en_US


        Human by Cjbeards | https://soundcloud.com/cjbeards
        Music promoted by https://www.free-stock-music.com
        Creative Commons Attribution 3.0 Unported License
        https://creativecommons.org/licenses/by/3.0/deed.en_US
    */

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this);
        bgMusicState = BGMusicState.NotPlaying;
        audioSource = GetComponent<AudioSource>();
        audioSource.volume = PlayerManager.GetMasterVolume();

        if (!menuBGAudioClip)
            Debug.LogError("No Menu BG Audio");

        if (!gameBGAudioClip)
            Debug.LogError("No Game BG Audio");

        Debug.Log("sound start");
      
    }
    
    public void SetVolume(float volume)
    {
        audioSource.volume = volume;
    }

    public void PlayMenuBG()
    {
        if(bgMusicState != BGMusicState.PlayingMenuBG)
        {
            audioSource.clip = menuBGAudioClip;
            audioSource.Play();
            audioSource.loop = true;
            bgMusicState = BGMusicState.PlayingMenuBG;
        }
    }

    public void PlayGameBG()
    {
        if (bgMusicState != BGMusicState.PlayingGameBG)
        {
            audioSource.clip = gameBGAudioClip;
            audioSource.Play();
            audioSource.loop = true;
            bgMusicState = BGMusicState.PlayingGameBG;
        }
    }

}
