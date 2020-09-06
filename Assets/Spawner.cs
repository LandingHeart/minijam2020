using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    private float spawnRate = 5f;
    public float spawnTime;
    public GameObject minion;
    public Transform leftSpawnPoint;
    public Transform rightSpawnPoint;
    private bool canSpawn = true;
    // Update is called once per frame
    void Update()
    {
        if(canSpawn)
        {   
            int num = Random.Range(0,2);
            if(num == 0){
                Instantiate(minion, leftSpawnPoint.position, leftSpawnPoint.rotation);
            }else{
                Instantiate(minion, rightSpawnPoint.position, rightSpawnPoint.rotation);
            }
            
            
            canSpawn = false;
            StartCoroutine(reset());
        }
       
    }
    IEnumerator reset() {
        yield return new WaitForSeconds(spawnRate);
        canSpawn = true;
    }
}
