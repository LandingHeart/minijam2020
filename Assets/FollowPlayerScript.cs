using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayerScript : MonoBehaviour
{
    [SerializeField] public Transform player;
    private float speed = 10f;
    [SerializeField] public Transform spawnPoint;
    private bool hasSpawned = false;

    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {   
        if(!hasSpawned){
            transform.position = Vector2.MoveTowards(transform.position, spawnPoint.position, 20f * Time.deltaTime);
            if(Vector2.Distance(transform.position,spawnPoint.position) < 0.2f){ // reached
                hasSpawned = true;
            }
        }else{
            if(player != null)
        {
            transform.position = Vector2.MoveTowards(transform.position,
  new Vector2(player.position.x, transform.position.y), speed * Time.deltaTime);
        }
        }

    }
}
