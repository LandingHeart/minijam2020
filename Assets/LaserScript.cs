using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserScript : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody2D rb;
   
    private Vector3 moveDir;
    public float bulletSpeed = 30f;
    private GameObject player;
    void Start()
    {
        //rb = GetComponent<Rigidbody2D>();
        player = GameObject.Find("Player");

        //moveDir = (playerTransform.transform.position - transform.position).normalized * bulletSpeed;
        //rb.velocity = new Vector2(moveDir.x, moveDir.y);
        moveDir = new Vector3(player.transform.position.x, player.transform.position.y, player.transform.position.z);

    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, moveDir, bulletSpeed * Time.deltaTime);

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
        Destroy(gameObject, 0.1f);

    }
}
