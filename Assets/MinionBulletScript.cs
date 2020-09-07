using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinionBulletScript : MonoBehaviour
{   
    [SerializeField] PlayerScript.myColors bulletColor;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {  
        if (collision.gameObject.CompareTag("Player"))
        {
            // Debug.Log("Hit player " + bulletColor);
            PlayerScript playerScript = collision.gameObject.GetComponent<PlayerScript>();
            playerScript.TakeDamage(5f, bulletColor);
            Destroy(gameObject);
        }
    }
}

