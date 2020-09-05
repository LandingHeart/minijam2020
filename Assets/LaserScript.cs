using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserScript : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody2D rb;
    public PlayerScript playerTransform;
    private Vector2 moveDir;
    public float bulletSpeed = 20f;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playerTransform = GameObject.FindObjectOfType<PlayerScript>();

        moveDir = (playerTransform.transform.position - transform.position).normalized * bulletSpeed;
        rb.velocity = new Vector2(moveDir.x, moveDir.y);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
