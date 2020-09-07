using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialRed : MonoBehaviour
{
    // Start is called before the first frame update
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Destroy(gameObject, 5f);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {  
        
        if (collision.gameObject.CompareTag("Enemy") || collision.gameObject.CompareTag("bullets") || collision.gameObject.CompareTag("Teeth")
        || collision.gameObject.CompareTag("RedBullet") || collision.gameObject.CompareTag("BlueBullet") || collision.gameObject.CompareTag("GreenBullet") || collision.gameObject.CompareTag("Laser"))
        {
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.CompareTag("Boss1") || collision.gameObject.CompareTag("Boss2"))
        {
            Destroy(gameObject);
        }

    }

}
