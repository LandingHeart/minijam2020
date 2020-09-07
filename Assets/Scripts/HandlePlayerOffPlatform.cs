using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandlePlayerOffPlatform : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject player;
    public GameObject platform;
    public Transform resetPlayerPosition;
    public PlayerScript playerScript;
    float dist = 0;
    void Start()
    {
        if(player)
            playerScript = player.GetComponent<PlayerScript>();
    }

    // Update is called once per frame
    void Update()
    {

        if(player){
            float dist = player.transform.position.y - platform.transform.position.y;
            // Debug.Log("platform: " + dist);
            if(dist < 0)
            {
                dist = dist * -1;
            }
            if(dist > 50f)
            {
                player.transform.position = resetPlayerPosition.position;
                playerScript.TakeDamage(20f);
                //Destroy(player);
            }

        }

    }
}
