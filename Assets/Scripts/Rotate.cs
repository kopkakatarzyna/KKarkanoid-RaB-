using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    float xPos;
    float yPos;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        xPos = gameObject.transform.root.position.x;
        yPos = gameObject.transform.root.position.y;
        // efekt drżenia i 'pływania' bloczków po scenie
        //if(yPos<107 || xPos<90 || xPos>-90)
        //iTween.ShakePosition(gameObject, new Vector3(0.1f, 0.1f, 0.1f), Time.deltaTime);
    }
}
