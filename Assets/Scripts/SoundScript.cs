using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundScript : MonoBehaviour
{
    AudioSource audioData;
    // Start is called before the first frame update
    void Start()
    {
        GetAudioData();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void GetAudioData()
    {
        audioData = GetComponent<AudioSource>();
    }
}
