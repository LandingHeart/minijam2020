using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    // Start is called before the first frame update
    public float currHp;
    public float maxHp = 1000f;
    public PlayerAim playerAim;
    public GameObject playerTransform;
    public GameObject bullet;
    public float bulletSpeed = 10f;
    private float fireRate = 1f;
    private float nextFire;
    private Rigidbody2D rb;
    private bool redBulletCollided = false;
    private bool greenBulletCollided = false;
    private bool blueBulletCollided = false;
    private SpriteRenderer sr;
    void Start()
    {
        currHp = maxHp;
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        playerTransform = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        CheckDistAndTimeToFire();
        CheckColorMix();
      //  Move();
    }
    public void Move()
    {
        
    }
    public void CheckColorMix() {
        if(redBulletCollided && blueBulletCollided) {
            sr.color = new Color(168, 0, 255);
        }

    }
    public void CheckDistAndTimeToFire() {
        float dist = Vector2.Distance(playerTransform.transform.position, transform.position);

        if (Time.time > nextFire)
        {
            if (dist < 10f)
            {
                Debug.Log("dist 10");
                nextFire = Time.time + fireRate;
                fireBullet();
            }
        }
    }
    public void fireBullet() {
        Instantiate(bullet, transform.position, transform.rotation);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("MyRedBullet"))
        {
            TakeDamage(playerAim.bulletDamge);
            redBulletCollided = true;
        }
        if (collision.gameObject.CompareTag("MyGreenBullet"))
        {
            TakeDamage(playerAim.bulletDamge);
            greenBulletCollided = true;
        }
        if (collision.gameObject.CompareTag("MyBlueBullet"))
        {
            TakeDamage(playerAim.bulletDamge);
            blueBulletCollided = true;
        }
    }
    private void TakeDamage(float damage) {
        currHp -= damage;

        if(currHp <= 0f)
        {
            Destroy(gameObject);
        }
    }
}
