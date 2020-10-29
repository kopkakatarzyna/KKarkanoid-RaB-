using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dontDestroy : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(GameObject.Find("Music").GetComponent<AudioSource>());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
