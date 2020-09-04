using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAim : MonoBehaviour
{
    // Start is called before the first frame update
    //public Transform aimTransform;
    private float fireRate = 0.1f;
    private float nextFire;
    [SerializeField]
    private GameObject bullet;
    public float speed = 50f;
    [SerializeField]
    private Transform firePoint;

    private int BulletCount;

    void Start()
    {


    }
    // Update is called once per frame
    void Update()
    {
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
    public void fireProjectile()
    {
        // spawn bullet object at firepoint location with firepoint rotation
        GameObject myBullet = Instantiate(bullet, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = myBullet.GetComponent<Rigidbody2D>();
        //add force to bullet
        rb.AddForce(firePoint.up * speed, ForceMode2D.Impulse);
    }


}
