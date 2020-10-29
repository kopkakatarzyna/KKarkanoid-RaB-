using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dontDestroySound : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(GameObject.Find("SoundObject").GetComponent<AudioSource>());
        DontDestroyOnLoad(GameObject.Find("SoundObject_1").GetComponent<AudioSource>());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
