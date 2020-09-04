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
   

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        playerScript = GetComponent<PlayerScript>();
        bulletColor = playerScript.currColors;

    }
    // Update is called once per frame
    void Update()
    {
        Debug.Log("current color is: " + playerScript.currColors);
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
        Rigidbody2D rb = myBullet.GetComponent<Rigidbody2D>();
        //add force to bullet
        rb.AddForce(firePoint.up * speed, ForceMode2D.Impulse);
    }


}
