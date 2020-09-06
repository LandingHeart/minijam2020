using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScript : MonoBehaviour
{   
    public GameObject boss1;
    public GameObject boss2;

    // Start is called before the first frame update
    void Start()
    {
        boss1 = GameObject.Find("Boss1");
        boss2 = GameObject.Find("Boss2");

        Debug.Log(boss1.activeSelf);

        boss1.SetActive(false);
        boss2.SetActive(false);

        Debug.Log(boss1.activeSelf);
        StartCoroutine(spawnBoss1());

    }

    // Update is called once per frame
    void Update()
    {
        if(!boss1 && boss2){
            // Debug.Log("boss1 die");
            StartCoroutine(spawnBoss2());
        }else if(!boss1 && !boss2){
            Debug.Log("Win");
        }
    }

    IEnumerator spawnBoss1(){
        yield return new WaitForSeconds(5f);
        if(boss1)
            boss1.SetActive(true);
    }

    IEnumerator spawnBoss2(){
        yield return new WaitForSeconds(5f);
        if(boss2)
            boss2.SetActive(true);
    }
}
