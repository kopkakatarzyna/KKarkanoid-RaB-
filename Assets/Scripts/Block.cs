using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Block : MonoBehaviour
{
    GameManager gameManager;
    AudioSource audioData;
    public Color c;
    Transform child;
    GameObject subBlock;
    public GameObject racket;
    public GameObject shootingRacket;
    string nameOfCollision;
    Ball ball;
    public GameObject blockWall;

    void Start()
    {
        gameManager = GameObject.FindObjectOfType<GameManager>();
        child = transform.GetChild(0);
        subBlock = child.gameObject;
        racket = GameObject.Find("racket");
        shootingRacket = GameObject.Find("shootingRacket");
        ball = GameObject.FindObjectOfType<Ball>();
        blockWall = GameObject.Find("blockWall");
    }
    private void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D collisionInfo)
    {
        if (gameObject.tag != "bW" && gameObject.tag != "staticBlock")
        {
            gameManager.score += 1;
            gameManager.setScene(gameManager.scene);
            gameManager.updateScore(gameManager.score);
            if (gameObject.tag == "3")
            {
                c = subBlock.GetComponent<SpriteRenderer>().color;
                if (c.a > 0.6f)
                {
                    audioData = GameObject.Find("SoundObject_1").GetComponent<AudioSource>();
                    audioData.Play(0);
                    c.a = 0.6f;
                }
                else if (c.a == 0.6f)
                {
                    audioData = GameObject.Find("SoundObject_1").GetComponent<AudioSource>();
                    audioData.Play(0);
                    c.a = 0.3f;
                }
                else
                {
                    audioData = GameObject.Find("SoundObject").GetComponent<AudioSource>();
                    audioData.Play(0);
                    Destroy(gameObject);
                }
                subBlock.GetComponent<SpriteRenderer>().color = c;
            }
            else if (gameObject.tag == "2")
            {
                c = subBlock.GetComponent<SpriteRenderer>().color;
                if (c.a > 0.5f)
                {
                    audioData = GameObject.Find("SoundObject_1").GetComponent<AudioSource>();
                    audioData.Play(0);
                    c.a = 0.5f;
                }
                else
                {
                    audioData = GameObject.Find("SoundObject").GetComponent<AudioSource>();
                    audioData.Play(0);
                    Destroy(gameObject);
                }
                subBlock.GetComponent<SpriteRenderer>().color = c;
            }
            else
            {
                if (gameObject.tag == "racket1")
                {
                    racket.transform.localScale = new Vector3(0.75f, racket.transform.localScale.y, racket.transform.localScale.z);
                }
                if (gameObject.tag == "racket2")
                {
                    racket.transform.localScale = new Vector3(2, racket.transform.localScale.y, racket.transform.localScale.z);
                }
                if (gameObject.tag == "shRacket1")
                {
                    shootingRacket.transform.localScale = new Vector3(0.75f, shootingRacket.transform.localScale.y, shootingRacket.transform.localScale.z);
                }
                if (gameObject.tag == "shRacket2")
                {
                    shootingRacket.transform.localScale = new Vector3(2, shootingRacket.transform.localScale.y, shootingRacket.transform.localScale.z);
                }
                if (gameObject.tag == "multi")
                {
                    ball.multiBall();
                }
                if (gameObject.tag == "blockWall")
                {
                    gameManager.createWall();
                }
                gameManager.setScene(gameManager.scene);
                gameManager.updateScore(gameManager.score);
                audioData = GameObject.Find("SoundObject").GetComponent<AudioSource>();
                audioData.Play(0);
                Destroy(gameObject);
            }
        }
    }
}
