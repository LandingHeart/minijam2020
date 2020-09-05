using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueBulletScript : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 10f;
    public Transform playerTransform;
    public float timer = 0;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if(timer > 3f)
        {
            Destroy(gameObject);
        }
        transform.position = Vector2.MoveTowards(transform.position, playerTransform.position, speed * Time.deltaTime);
    }
}
