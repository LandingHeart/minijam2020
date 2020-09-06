using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAim : MonoBehaviour
{
    // Start is called before the first frame update
    //public Transform aimTransform;
 
    [SerializeField]
    private GameObject bullet;
    public float speed = 100f;
    [SerializeField] private Transform firePoint;
    [SerializeField] private Transform firePoint1;
    [SerializeField] private Transform firePoint2;
    private PlayerScript playerScript;
    private SpriteRenderer sr;

        
    private int BulletCount;
    PlayerScript.myColors bulletColor;
    public float bulletDamge = 10f;
    private PlayerScript.myColors red;
    private PlayerScript.myColors blue;
    private PlayerScript.myColors green;
    private PlayerScript.myColors white;
    
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
            Debug.Log("red bullet " + bulletDamge);
            

            myBullet = Instantiate(bullet, firePoint.position, firePoint.rotation);
            SpriteRenderer bulletSpriteRenderer = myBullet.GetComponent<SpriteRenderer>();
            bulletSpriteRenderer.color = playerScript.sr.color;
            myBullet.tag = "MyRedBullet";
            //set damage;
        }
        else if (bulletColor.Equals(green) )
        {
            bulletDamge = 12;
            Debug.Log("green bullet" + bulletDamge);

            myBullet = Instantiate(bullet, firePoint.position, firePoint.rotation);
            SpriteRenderer bulletSpriteRenderer = myBullet.GetComponent<SpriteRenderer>();
            bulletSpriteRenderer.color = playerScript.sr.color;
            myBullet.tag = "MyGreenBullet";
        }
        else if (bulletColor.Equals(blue))
        {
            bulletDamge = 15;
            Debug.Log("blue bullet" + bulletDamge);
            myBullet = Instantiate(bullet, firePoint.position, firePoint.rotation);
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
        }
        else if (bulletColor.Equals(white))
        {
            myBullet = Instantiate(bullet, firePoint.position, firePoint.rotation);
            bulletDamge = 5f;
            myBullet.tag = "MyWhiteBullet";
            Debug.Log("white bullet " + bulletDamge);
        }
        if(myBullet){
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
