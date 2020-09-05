using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    // Start is called before the first frame update
    public float currHp;
    public float maxHp = 100f;
    PlayerAim playerAim;
    public Transform playerTransform;
    public GameObject bullet;
    public float bulletSpeed = 10f;
    private float fireRate = 1f;
    private float nextFire;
    private Rigidbody2D rb;
    void Start()
    {
        currHp = maxHp;
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        CheckDistAndTimeToFire();
      //  Move();
    }
    public void Move()
    {
        
    }
    public void CheckDistAndTimeToFire() {
        float dist = Vector2.Distance(playerTransform.position, transform.position);

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
        }
        if (collision.gameObject.CompareTag("MyGreenBullet"))
        {
            TakeDamage(playerAim.bulletDamge);
        }
        if (collision.gameObject.CompareTag("MyBlueBullet"))
        {
            TakeDamage(playerAim.bulletDamge);
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
