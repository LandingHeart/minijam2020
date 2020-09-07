using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAim : MonoBehaviour
{
    // Start is called before the first frame update
    //public Transform aimTransform;
 
    [SerializeField] private GameObject bullet;
    [SerializeField] private GameObject specialRedBullet;
    public float speed = 100f;
    [SerializeField] private Transform firePoint;
    [SerializeField] private Transform firePoint1;
    [SerializeField] private Transform firePoint2;
    private PlayerScript playerScript;
    private SpriteRenderer sr;

        
    private int BulletCount;
    PlayerScript.myColors bulletColor;
    public float bulletDamage = 10f;
    private PlayerScript.myColors red;
    private PlayerScript.myColors blue;
    private PlayerScript.myColors green;
    private PlayerScript.myColors white;

    private float red_damage = 50f;
    private float green_damage = 0.5f;
    private float blue_damage = 15f;
    private float default_damage = 10f;
    
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        playerScript = GetComponent<PlayerScript>();
        bulletColor = playerScript.currColors;
        red = PlayerScript.myColors.RED;
        blue = PlayerScript.myColors.BLUE;
        green = PlayerScript.myColors.GREEN;
        white = PlayerScript.myColors.DEFAULT;

    }
    // Update is called once per frame
    void Update()
    {
        
        bulletColor = playerScript.currColors;
        // obtain mouse pos to shoot at mouse
        Vector3 mousepos = Input.mousePosition;
        //get mouse position
        mousepos = Camera.main.ScreenToWorldPoint(mousepos);
        // calculate mous position
        Vector2 dir = new Vector2(mousepos.x - transform.position.x, mousepos.y - transform.position.y);
        //set direction, up.
        transform.up = dir;

        //right mouse clicked, add bullet count
        if (Input.GetButtonDown("Fire1"))
        {
            //fire bullet
            fireProjectile();
        }

        if(Input.GetButton("Fire1") && playerScript.green_bullets > 0 && playerScript.currColors == green){
            //fire bullet
            fireProjectile();
        }
    }
    public void ColorChange() {
        if (playerScript.sr.Equals(Color.red))
        {

        } 
    }
    public void fireProjectile()
    {
        // spawn bullet object at firepoint location with firepoint rotation
        GameObject myBullet = null;
        if (bulletColor.Equals(red))
        {
            
            if(playerScript.red_bullets > 0){
                myBullet = Instantiate(specialRedBullet, firePoint.position, firePoint.rotation);
                bulletDamage = red_damage;
                SpriteRenderer bulletSpriteRenderer = myBullet.GetComponent<SpriteRenderer>();
                bulletSpriteRenderer.color = playerScript.sr.color;
                myBullet.tag = "MyRedBullet";
                Debug.Log("red bullet " + bulletDamage);
                playerScript.useAColorBullet(red);
            }else{
                myBullet = Instantiate(bullet, firePoint.position, firePoint.rotation);
                bulletDamage = default_damage;
                myBullet.tag = "MyWhiteBullet";
                Debug.Log("white bullet " + bulletDamage);
            }
            Rigidbody2D rb = myBullet.GetComponent<Rigidbody2D>();
            //add force to bullet
            rb.AddForce(firePoint.up * (speed / 7.0f), ForceMode2D.Impulse);
        }
        else if (bulletColor.Equals(green) )
        {   
            if(playerScript.green_bullets > 0){
                myBullet = Instantiate(bullet, firePoint.position, firePoint.rotation);
                bulletDamage = green_damage;
                SpriteRenderer bulletSpriteRenderer = myBullet.GetComponent<SpriteRenderer>();
                bulletSpriteRenderer.color = playerScript.sr.color;
                myBullet.tag = "MyGreenBullet";
                Debug.Log("green bullet" + bulletDamage);
                playerScript.useAColorBullet(green);
            }else{
                myBullet = Instantiate(bullet, firePoint.position, firePoint.rotation);
                bulletDamage = default_damage;
                myBullet.tag = "MyWhiteBullet";
                Debug.Log("white bullet " + bulletDamage);
            }
            Rigidbody2D rb = myBullet.GetComponent<Rigidbody2D>();
            //add force to bullet
            rb.AddForce(firePoint.up * speed, ForceMode2D.Impulse);
        }
        else if (bulletColor.Equals(blue))
        {
            if(playerScript.blue_bullets > 0){
                Debug.Log("blue bullet" + bulletDamage);
                myBullet = Instantiate(bullet, firePoint.position, firePoint.rotation);
                bulletDamage = blue_damage;
                GameObject myBullet1 = Instantiate(bullet, firePoint1.position, firePoint1.rotation);
                GameObject myBullet2 = Instantiate(bullet, firePoint2.position, firePoint2.rotation);

                SpriteRenderer bulletSpriteRenderer = myBullet.GetComponent<SpriteRenderer>();
                bulletSpriteRenderer.color = playerScript.sr.color;
                myBullet.tag = "MyBlueBullet";

                SpriteRenderer bulletSpriteRenderer1 = myBullet1.GetComponent<SpriteRenderer>();
                bulletSpriteRenderer1.color = playerScript.sr.color;
                myBullet1.tag = "MyBlueBullet";

                SpriteRenderer bulletSpriteRenderer2 = myBullet2.GetComponent<SpriteRenderer>();
                bulletSpriteRenderer2.color = playerScript.sr.color;
                myBullet2.tag = "MyBlueBullet";

                Rigidbody2D rb1 = myBullet1.GetComponent<Rigidbody2D>();
                //add force to bullet
                rb1.AddForce(firePoint1.up * speed, ForceMode2D.Impulse);

                Rigidbody2D rb2 = myBullet2.GetComponent<Rigidbody2D>();
                //add force to bullet
                rb2.AddForce(firePoint2.up * speed, ForceMode2D.Impulse);
                playerScript.useAColorBullet(blue);
            }else{
                myBullet = Instantiate(bullet, firePoint.position, firePoint.rotation);
                bulletDamage = default_damage;
                myBullet.tag = "MyWhiteBullet";
                Debug.Log("white bullet " + bulletDamage);
            }
            Rigidbody2D rb = myBullet.GetComponent<Rigidbody2D>();
            //add force to bullet
            rb.AddForce(firePoint.up * speed, ForceMode2D.Impulse);
        }
        else if (bulletColor.Equals(white))
        {
            myBullet = Instantiate(bullet, firePoint.position, firePoint.rotation);
            bulletDamage = default_damage;
            myBullet.tag = "MyWhiteBullet";
            Debug.Log("white bullet " + bulletDamage);
            Rigidbody2D rb = myBullet.GetComponent<Rigidbody2D>();
            //add force to bullet
            rb.AddForce(firePoint.up * speed, ForceMode2D.Impulse);
        }
        
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Boss1"))
        {
            // Destroy(gameObject);
        }

    }


}
