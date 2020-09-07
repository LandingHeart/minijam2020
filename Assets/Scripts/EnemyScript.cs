using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    // Start is called before the first frame update
    public float currHp;
    public float maxHp = 25f;
    public PlayerAim playerAim;
    public GameObject playerTransform;
    public GameObject redBullet;
    public GameObject greenBullet;
    public GameObject blueBullet;
    public float bulletSpeed = 10f;
    private float fireRate = 1f;
    private float nextFire;
    private Rigidbody2D rb;
    private bool redBulletCollided = false;
    private bool greenBulletCollided = false;
    private bool blueBulletCollided = false;
    private SpriteRenderer sr;
    private Color red;
    private Color blue;
    private Color green;
    public float speed;
    public float force;

    public PlayerScript.myColors currColor;
    void Start()
    {
        currHp = maxHp;
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponentInChildren<SpriteRenderer>();
        playerTransform = GameObject.Find("Player");
        red = Color.red;
        blue = Color.blue;
        green = Color.green;
        speed = 8f;
        GetMyColor();
        
    }

    // Update is called once per frame
    void Update()
    {   
        CheckDistAndTimeToFire();
        CheckColorMix();
        Move();
        if(playerTransform){
            float dist = Vector2.Distance(transform.position, playerTransform.transform.position);
            if( dist < 15f)
            {
                rb.velocity = Vector3.zero;
            }
        }
        
    
      //  Move();
    }
   
    public void Move()
    {
        if(playerTransform){
            if(playerTransform.transform.position.x > transform.position.x)
            {
                rb.velocity = transform.right * speed;
            }else
            {   //move left
                rb.velocity = -transform.right * speed;

            }
        }

    }
    private void GetMyColor() {
        int random = (int)Random.Range(0, 3);
        if (random == 0)
        {
            sr.color = red;
            currColor = PlayerScript.myColors.RED;
        }
        else if (random == 1)
        {
            sr.color = blue;
            currColor = PlayerScript.myColors.BLUE;
        }
        else
        {
            sr.color = green;
            currColor = PlayerScript.myColors.GREEN;
        }
    }

    public void CheckColorMix() {
        if(redBulletCollided && blueBulletCollided) {
            sr.color = new Color(168, 0, 255);
        }

    }
    public void CheckDistAndTimeToFire() {
        if(playerTransform){
            float dist = Vector2.Distance(playerTransform.transform.position, transform.position);
            float random = Random.Range(0, 10);
            if (Time.time > nextFire)
            {
                if (dist < random)
                {
                    // Debug.Log("dist 10");
                    nextFire = Time.time + fireRate;
                    fireBullet();
                }
            }
        }
    }
    public void fireBullet() {
        if (sr.color.Equals(red))
        {
            Instantiate(redBullet, transform.position, transform.rotation);
        }
        if (sr.color.Equals(green))
        {
            Instantiate(greenBullet, transform.position, transform.rotation);
        }
        if (sr.color.Equals(blue))
        {
            Instantiate(blueBullet, transform.position, transform.rotation);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //if (collision.gameObject.CompareTag("MyRedBullet"))
        //{
        //    TakeDamage(playerAim.bulletDamge);
        //    redBulletCollided = true;
        //}
        //if (collision.gameObject.CompareTag("MyGreenBullet"))
        //{
        //    TakeDamage(playerAim.bulletDamge);
        //    greenBulletCollided = true;
        //}
        //if (collision.gameObject.CompareTag("MyBlueBullet"))
        //{
        //    TakeDamage(playerAim.bulletDamge);
        //    blueBulletCollided = true;
        //}
        //if (collision.gameObject.CompareTag("MyWhiteBullet"))
        //{
        //    TakeDamage(playerAim.bulletDamge);
       
        //}
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("MyRedBullet"))
        {
            // TakeDamage(playerAim.bulletDamge); // 有问题
            TakeDamage(20f);
            Debug.Log("hit my red bullet");
            redBulletCollided = true;
        }
        if (collision.gameObject.CompareTag("MyGreenBullet"))
        {
            // TakeDamage(playerAim.bulletDamge);
            TakeDamage(20f);
            Debug.Log("hit my green bullet");
            greenBulletCollided = true;
        }
        if (collision.gameObject.CompareTag("MyBlueBullet"))
        {
            //TakeDamage(playerAim.bulletDamge);
            TakeDamage(20f);
            Debug.Log("hit my blue bullet");
            blueBulletCollided = true;
        }
        if (collision.gameObject.CompareTag("MyWhiteBullet"))
        {
            //TakeDamage(playerAim.bulletDamge);
            Debug.Log("hit my white bullet");
            TakeDamage(15f);

        }
    }
    private void TakeDamage(float damage) {
        currHp -= damage;
        sr.color = Color.white;
        if(currHp <= 0f) // die, let player absorb
        {   
            GameObject player = GameObject.Find("Player");
            if(player){
                PlayerScript playerScript = player.GetComponent<PlayerScript>();
                playerScript.Absorb(currColor);
            }
            

            Destroy(gameObject);
            
        }
    }
  
}
