using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenBulletScript : MonoBehaviour
{
    // Start is called before the first frame update
    // Start is called before the first frame update
    public float speed = 10f;
    public float timer = 0;
    private GameObject target;
    private Vector2 moveDir;
    private Rigidbody2D rb;
    void Start()
    {
        //playerTransform = GameObject.Find("Player").transform;
        target = GameObject.Find("Player");
        rb = GetComponent<Rigidbody2D>();
        if (target != null)
        {
            moveDir = (target.transform.position - transform.position).normalized * speed;
            rb.velocity = new Vector2(moveDir.x, moveDir.y);
        }
        // Update is called once per frame
        void Update()
        {
            timer += Time.deltaTime;
            if (timer > 3f)
            {
                Destroy(gameObject);
            }

            //这段是 跟踪弹；
            //transform.position = Vector2.MoveTowards(transform.position, playerTransform.position, speed * Time.deltaTime);
        }
    }
}