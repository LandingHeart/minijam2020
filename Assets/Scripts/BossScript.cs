using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossScript : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform player;
    public float speed = 5f;

    void Start()
    {
        //transform.position = new Vector2(player.position.x, transform.position.y);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position,
            new Vector2(player.position.x, transform.position.y), speed * Time.deltaTime);

    }
}
