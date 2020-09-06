using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayerScript : MonoBehaviour
{
    [SerializeField] public Transform player;
    private float speed = 10f;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(player != null)
        {
            transform.position = Vector2.MoveTowards(transform.position,
  new Vector2(player.position.x, transform.position.y), speed * Time.deltaTime);
        }
    }
}
