using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingRacket : MonoBehaviour
{
    // Movement Speed
    public float speed = 150;
    public int resized = 0;
    public GameObject leftBullet;
    public GameObject rightBullet;
    public GameObject Projectile;
    public float waitTime = 0.6f;
    public float timer = 0.0f;
    public bool shot = true;


    // Start is called before the first frame update
    void Start()
    {
        leftBullet = GameObject.Find("leftBullet");
        rightBullet = GameObject.Find("rightBullet");
        Projectile = GameObject.Find("Projectile");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            spawnBullet();
        }
    }

    void FixedUpdate()
    {
        updateShoot();

        // Get Horizontal Input
        float h = Input.GetAxisRaw("Horizontal");

        // Set Velocity (movement direction * speed)
        GetComponent<Rigidbody2D>().velocity = Vector2.right * h * speed;
        updateBulletPosition();
    }
    public void updateBulletPosition()
    {
        leftBullet.transform.position = new Vector3(gameObject.transform.position.x - 9.6f, -99.4f, 0);
        rightBullet.transform.position = new Vector3(gameObject.transform.position.x + 9.6f, -99.4f, 0);
    }

    public void spawnBullet()
    {
        if (shot==true)
        {
            shoot(leftBullet);
            shoot(rightBullet);
            shot = false;
        }
    }

    public void shoot(GameObject bullet)
    {
        Vector3 shootPosition = new Vector3(bullet.transform.position.x, bullet.transform.position.y, bullet.transform.position.z);
        GameObject shoot = Instantiate(Projectile, shootPosition, Quaternion.identity);
        Rigidbody2D shootRb = shoot.GetComponent<Rigidbody2D>();
        shootRb.AddForce(transform.up * 5000);
    }

    public void updateShoot()
    {
        timer += Time.deltaTime;
        if (timer > waitTime)
        {
            shot = true;
            timer = timer - waitTime;
        }
    }
}
