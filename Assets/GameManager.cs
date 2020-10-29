using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int scene;
    public Scene currentScene;
    public int score = 0;
    public static int ballCounter=0;
    public string scoreValue;
    public static GameObject blockWall;

    // Start is called before the first frame update
    void Start()
    {
        blockWall = GameObject.FindGameObjectWithTag("wall");
        for (int i = 0; i < 13; i++)
        {
            blockWall.transform.GetChild(i).gameObject.SetActive(false);
        }

        currentScene = SceneManager.GetActiveScene();
        if (currentScene.name == "1level") scene = 1;
        if (currentScene.name == "2level") scene = 2;
        if (currentScene.name == "3level") scene = 3;
        if (currentScene.name == "4level") scene = 4;
        if (currentScene.name == "5level") scene = 5;
    }

    // Update is called once per frame
    void Update()
    {
        GetInputKey();
        isBallBelowBorderGM();
    }

    public void GetInputKey()
    {
        if (Input.GetKey(KeyCode.R))
        {
            SceneManager.LoadScene(currentScene.name, LoadSceneMode.Single);
        }
        if (Input.GetKey(KeyCode.N))
        {
            SceneManager.LoadScene(currentScene.buildIndex + 1);
        }
        if (Input.GetKey(KeyCode.B))
        {
            createWall();
        }
        if (Input.GetKey(KeyCode.M))
        {
            SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);
        }
    }
    
    public void updateScore(int x)
    {
        string stringValue = x.ToString();
        Debug.Log("Score: " + stringValue);
    }

    public void setScene(int scene)
    {
        if (scene == 1)
        {
            if (score == 60)
            {
                SceneManager.LoadScene("2level", LoadSceneMode.Single);
            }
        }
        if (scene == 2)
        {
            if (score == 110)
            {
                SceneManager.LoadScene("3level", LoadSceneMode.Single);
            }
        }
        if (scene == 3)
        {
            if (score == 80)
            {
                SceneManager.LoadScene("4level", LoadSceneMode.Single);
            }
        }
        if (scene == 4)
        {
            if (score == 94)
            {
                SceneManager.LoadScene("5level", LoadSceneMode.Single);
            }
        }
        if (scene == 5)
        {
            if (score == 60)
            {
                SceneManager.LoadScene("FinalScene", LoadSceneMode.Single);
            }
        }
    }

    public int getBallCounter()
    {
        return ballCounter;
    }

    public void decreaseBallCounter()
    {
        ballCounter--;
    }

    public void increaseBallCounter()
    {
        ballCounter++;
    }

    public void isBallBelowBorderGM()
    {
        if (ballCounter < 0)
        {
            ballCounter = 0;
            SceneManager.LoadScene(currentScene.name, LoadSceneMode.Single);
        }
    }

    public void createWall()
    {
        for (int i = 0; i < 13; i++)
        {
            if(!blockWall.transform.GetChild(i).gameObject.activeSelf)
                blockWall.transform.GetChild(i).gameObject.SetActive(true);
        }
    }
}
