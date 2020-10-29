using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    public GameObject Options;
    AudioSource audioData;
    public void StartGame()
    {
        SceneManager.LoadScene("1level", LoadSceneMode.Single);
    }

    public void ShowOptions()
    {
        Options.SetActive(true);
    }

    public void setSoundOn()
    {
        audioData = GameObject.Find("SoundObject").GetComponent<AudioSource>();
        audioData.volume = 1;
        audioData = GameObject.Find("SoundObject_1").GetComponent<AudioSource>();
        audioData.volume = 1;
    }

    public void setSoundOff()
    {
        audioData = GameObject.Find("SoundObject").GetComponent<AudioSource>();
        audioData.volume = 0;
        audioData = GameObject.Find("SoundObject_1").GetComponent<AudioSource>();
        audioData.volume = 0;
    }

    public void backToMainMenu()
    {
        Options.SetActive(false);
    }

    public void setMusicOn()
    {
        audioData = GameObject.Find("Music").GetComponent<AudioSource>();
        audioData.volume = 1;
    }

    public void setMusicOff()
    {
        audioData = GameObject.Find("Music").GetComponent<AudioSource>();
        audioData.volume = 0;
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    // Start is called before the first frame update
    void Start()
    {
        Options = GameObject.FindGameObjectWithTag("Options");
        Options.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
