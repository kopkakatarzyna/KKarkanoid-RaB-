using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public GameObject ball;
    Scene currentScene;
    // Movement Speed
    public float speed = 5f;
    GameManager gM;

    // Start is called before the first frame update
    void Start()
    {
        gM = GameObject.FindObjectOfType<GameManager>();
        GetComponent<Rigidbody2D>().velocity = Vector2.up * speed;
        currentScene = SceneManager.GetActiveScene();
        ball = GameObject.Find("ball");
    }

    void Update()
    {
        isBallBelowBorder();
        gameObject.GetComponent<CircleCollider2D>().sharedMaterial.bounciness = 1.0f;
    }


    void OnCollisionEnter2D(Collision2D col)
    {
        if (GetComponent<Rigidbody2D>().velocity.x == 0 || GetComponent<Rigidbody2D>().velocity.y == 0)
            GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x + Random.Range(-0.5f, 0.5f), GetComponent<Rigidbody2D>().velocity.y + Random.Range(-0.5f, 0.5f));

        if (col.gameObject.name == "racket" || col.gameObject.name=="shootingRacket")
        {
            float x = hitFactor(transform.position,col.transform.position,col.collider.bounds.size.x);
            Vector2 dir = new Vector2(x, 1).normalized;
            GetComponent<Rigidbody2D>().velocity = dir * speed;
        }
    }

    float hitFactor(Vector2 ballPos, Vector2 racketPos,
                float racketWidth)
    {
        return (ballPos.x - racketPos.x) / racketWidth;
    }

    public void multiBall()
    {
        for(int i=0; i<3; i++)
        {
            GameObject multiBall = Instantiate(ball, gameObject.transform.position, Quaternion.identity);
            Rigidbody2D multiBallRB = multiBall.GetComponent<Rigidbody2D>();
            if(i==0) multiBallRB.AddForce(transform.up);
            if(i==1) multiBallRB.AddForce(new Vector2(-1,1));
            if (i == 2) multiBallRB.AddForce(new Vector2(1,1));
            gM.increaseBallCounter();
        }
    }

    public void isBallBelowBorder()
    {
        if (transform.position.y <= -110)
        {
            gM.decreaseBallCounter();
            Destroy(gameObject);
        }
    }
}
