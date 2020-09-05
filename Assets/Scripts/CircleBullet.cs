using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleBullet : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    int numProjectiles;

    [SerializeField]
    GameObject myProjectile;

    Vector2 starpos;

    private float radius, speed;
    public static bool fire = false;
    private bool toFire = false;

    private float fireRate = 1f;
    private float nextFire;

    public GameObject launchPoint;

    void Start()
    {
        radius = 5f;
        speed = 20f;
        spawnProjectile(numProjectiles);
    }

    // Update is called once per frame
    void Update()
    {   
      
            //starpos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            if (Time.time > nextFire)
            {
                nextFire = Time.time + fireRate;
                spawnProjectile(numProjectiles);
            }
        
    }
    void spawnProjectile(int num)
    {
        float angleStep = 360f / num;
        float angle = 0f;

        for (int i = 0; i <= num - 1; i++)
        {
            float dirXpos = transform.position.x + Mathf.Sin((angle * Mathf.PI) / 180) * radius;

            float dirYpos = transform.position.y + Mathf.Cos((angle * Mathf.PI) / 180) * radius;

            Vector3 projectileVector = new Vector3(dirXpos, dirYpos, 0);
            Vector3 projectileMoveDir = (projectileVector - launchPoint.transform.position).normalized * speed;

            var proj = Instantiate(myProjectile, launchPoint.transform.position, Quaternion.identity);
            proj.GetComponent<Rigidbody2D>().velocity =
                new Vector2(projectileMoveDir.x, projectileMoveDir.y);

            angle += angleStep;
            Destroy(proj, 1f);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
        }

    }
}
