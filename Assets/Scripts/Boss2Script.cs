using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss2Script : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform player;
    public float speed = 10;
    public float attackSpeed = 100;
    private float waitTime;
    public float startWaitTime = 1;

    public Transform[] moveSpots;
    private int randomMoveSpot;

    public Transform[] attackSpots;
    private int randomAttackSpot;

    private int pattern = 0; // 0 = idle, 1 = attack
    private bool isPatternStarted = false; // if a pattern is started

    void Start()
    {
        //transform.position = new Vector2(player.position.x, transform.position.y);
        waitTime = startWaitTime;
        randomMoveSpot = Random.Range(0, moveSpots.Length);
        randomAttackSpot = Random.Range(0, attackSpots.Length);
    }

    // Update is called once per frame
    void Update()
    {
        if(isPatternStarted){ // continue to wait
            switch(pattern){
                case 0: // idle
                    idleMoving();
                    break;
                case 1: // attack
                    attackMoving();
                    break;
                default:
                    break;
            }
        }else{ // choose a pattern
            pattern = Random.Range(0, 2);
            isPatternStarted = true;
        }
    }

    void idleMoving(){
        Debug.Log("Idling");
        transform.position = Vector2.MoveTowards(transform.position,
           moveSpots[randomMoveSpot].position, speed * Time.deltaTime);

        if(Vector2.Distance(transform.position, moveSpots[randomMoveSpot].position) < 0.2f){
            if(waitTime <= 0){
                randomMoveSpot = Random.Range(0, moveSpots.Length);
                waitTime = startWaitTime;
                Debug.Log("Finished.");
                isPatternStarted = false;
            }else{
                waitTime -= Time.deltaTime;
            }
        }
    }

    void attackMoving(){
        Debug.Log("Attacking");
        transform.position = Vector2.MoveTowards(transform.position,
           attackSpots[randomAttackSpot].position, attackSpeed * Time.deltaTime);

        if(Vector2.Distance(transform.position,  attackSpots[randomAttackSpot].position) < 0.2f){
            if(waitTime <= 0){
                randomAttackSpot = Random.Range(0, attackSpots.Length);
                waitTime = startWaitTime;
                Debug.Log("Finished.");
                isPatternStarted = false;
            }else{
                waitTime -= Time.deltaTime;
            }
        }
    }
}
