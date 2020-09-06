using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public float spawnRate = 1f;
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
            Instantiate(minion, leftSpawnPoint.position, leftSpawnPoint.rotation);
            Instantiate(minion, rightSpawnPoint.position, rightSpawnPoint.rotation);
            canSpawn = false;
            StartCoroutine(reset());
        }
       
    }
    IEnumerator reset() {
        yield return new WaitForSeconds(3f);
        canSpawn = true;
    }
}
