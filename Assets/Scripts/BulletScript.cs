using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    // Start is called before the first frame update
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Destroy(gameObject, 1f);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {  
        if (collision.gameObject.CompareTag("Enemy") || collision.gameObject.CompareTag("Boss1") || collision.gameObject.CompareTag("Boss2"))
        {
            Destroy(gameObject, 0.1f);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("ground"))
        {
            Destroy(gameObject, 0.1f);
        }
        

        
    }
}
