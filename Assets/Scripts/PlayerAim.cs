using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAim : MonoBehaviour
{
    // Start is called before the first frame update
    //public Transform aimTransform;
 
    [SerializeField]
    private GameObject bullet;
    public float speed = 50f;
    [SerializeField]
    private Transform firePoint;
    private PlayerScript playerScript;
    private SpriteRenderer sr;
    private int BulletCount;
    PlayerScript.myColors bulletColor;
    public float bulletDamge = 10f;
    private Color red;
    private Color blue;
    private Color green;
    

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        playerScript = GetComponent<PlayerScript>();
        bulletColor = playerScript.currColors;
        red = Color.red;
        blue = Color.blue;
        green = Color.green;

    }
    // Update is called once per frame
    void Update()
    {
        bulletColor = playerScript.currColors;
        // obtain mouse pos to shoot at mouse
        Vector3 mousepos = Input.mousePosition;
        mousepos = Camera.main.ScreenToWorldPoint(mousepos);
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
        GameObject myBullet = Instantiate(bullet, firePoint.position, firePoint.rotation);
        SpriteRenderer bulletColor = myBullet.GetComponent<SpriteRenderer>();
        bulletColor.color = playerScript.sr.color;
        if (bulletColor.color.Equals(red))
        {
            Debug.Log("red bullet. damage " + bulletDamge);
            myBullet.tag = "MyRedBullet";

            //set damage;
        }
        if (bulletColor.color.Equals(green) )
        {
            bulletDamge = 12;
            myBullet.tag = "MyGreenBullet";
            Debug.Log("green bullet" + bulletDamge);
        }
        if (bulletColor.color.Equals(blue))
        {
            bulletDamge = 13;
            myBullet.tag = "MyBlueBullet";
            Debug.Log("blue bullet" + bulletDamge);
        }
        Rigidbody2D rb = myBullet.GetComponent<Rigidbody2D>();
        //add force to bullet
        rb.AddForce(firePoint.up * speed, ForceMode2D.Impulse);
    }


}
