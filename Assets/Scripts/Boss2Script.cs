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

    private int attackMoveCount = 0; // current attack move count
    private int maxAttackMove = 3;  // attack at most 3 times in a row
    private int idleMoveCount = 0; // current idle move count
    private int maxIdleMove = 2;  // idle at most 2 times in a row

    private int waves;

    public Transform[] moveSpots;
    private int randomMoveSpot;

    public Transform[] attackSpots;
    private int randomAttackSpot;

    private int pattern = 0; // 0 = idle, 1 = attack
    private bool isPatternStarted = false; // if a pattern is started


    [SerializeField] int numProjectiles;
    [SerializeField] GameObject boss2_red_bullet;
    [SerializeField] GameObject boss2_blue_bullet;
    [SerializeField] GameObject boss2_green_bullet;
    Vector2 starpos;

    private float radius, bulletSpeed;
    public static bool fire = false;
    private bool toFire = false;

    private float fireRate = 0.3f;
    private float nextFire;

    public GameObject launchPoint;


    void Start()
    {
        //transform.position = new Vector2(player.position.x, transform.position.y);
        waitTime = startWaitTime;
        randomMoveSpot = Random.Range(0, moveSpots.Length);
        randomAttackSpot = Random.Range(0, attackSpots.Length);

        radius = 5f;
        bulletSpeed = 15f;
        waves = Random.Range(1, 3);
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
            switch(pattern){
                case 0: // idle
                    idleMoveCount += 1;
                    break;
                case 1: // attack
                    attackMoveCount += 1;
                    break;
                default:
                    break;
            }
            if(attackMoveCount == maxAttackMove){  // attack too many times, force to idle
                pattern = 0;
                attackMoveCount = 0;
                idleMoveCount = 0;
            }
            if(idleMoveCount == maxIdleMove){  // attack too many times, force to attack
                pattern = 1;
                attackMoveCount = 0;
                idleMoveCount = 0;
            }
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
                waves = Random.Range(1, 3);
            }else{
                waitTime -= Time.deltaTime;
                if(waves > 0 && Time.time > nextFire){
                    nextFire = Time.time + fireRate;
                    spawnProjectile(Random.Range(numProjectiles-5, numProjectiles+5));
                    waves -= 1;
                }
            }
        }
    }

    void spawnProjectile(int num)
    {
        float angleStep = 360f / num;
        float angle = 0f;
        // choose bullet
        GameObject bullet;
        int color = Random.Range(0, 3); // 0 red, 1 blue, 2 green
        switch(color){
            case 0:
                bullet = boss2_red_bullet;
                break;
            case 1:
                bullet = boss2_blue_bullet;
                break;
            case 2:
                bullet = boss2_green_bullet;
                break;
            default:
                bullet = boss2_red_bullet;
                break;

        }

        for (int i = 0; i <= num - 1; i++)
        {
            float dirXpos = transform.position.x + Mathf.Sin((angle * Mathf.PI) / 180) * radius;

            float dirYpos = transform.position.y + Mathf.Cos((angle * Mathf.PI) / 180) * radius;

            Vector3 projectileVector = new Vector3(dirXpos, dirYpos, 0);
            Vector3 projectileMoveDir = (projectileVector - launchPoint.transform.position).normalized * bulletSpeed;

            var proj = Instantiate(bullet, launchPoint.transform.position, Quaternion.identity);
            proj.GetComponent<Rigidbody2D>().velocity =
                new Vector2(projectileMoveDir.x, projectileMoveDir.y);

            angle += angleStep;
            Destroy(proj, 1f);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
        }

    }
}
