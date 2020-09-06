using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeethScript : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(gameObject, 10f);
        if (collision.gameObject.CompareTag("Player")) {
            Destroy(gameObject);
        }

    }
}
