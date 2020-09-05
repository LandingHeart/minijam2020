using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossScript : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform player;
    public float speed = 10f;
    public float maxHp;
    public GameObject leftTeeth;
    public GameObject rightTeeth;
    public Transform[] teethPointLeft;// 2 teeth
    public Transform[] teethPointRight;// 2 teeth

    private float currHp;
    public float movementCD = 10f;
    public float fireRate = 0.2f;
    public float nextFire;
    private bool cd = false;
    public LineRenderer line;
    public Transform laserHit;
    public GameObject laser;
    private bool laserCd = false;

    void Start()
    {
        //transform.position = new Vector2(player.position.x, transform.position.y);
        line = GetComponentInChildren<LineRenderer>();
        line.enabled = false;
        line.useWorldSpace = true;
    }

    // Update is called once per frame
    void Update()
    {
        movementCD -= Time.time;
        float dist = player.position.x - transform.position.x;
        if (dist < 0)
        {
            dist = dist * -1;
           
        }
        if(dist <= 0f)
        {
            if(cd == false)
            {
                SentTeeth();
                StartCoroutine(TeethColdDown());
            }
        }

        if (laserCd == false)
        {
            LaserAttack();
            StartCoroutine(MyLaserCd());
        }

        Debug.Log("dist " + dist);
        Move();
        
        //transform.position = Vector2.MoveTowards(transform.position,
        //           new Vector2(player.position.x, transform.position.y), speed * Time.deltaTime);
    }
    IEnumerator MyLaserCd() {
        yield return new WaitForSeconds(1f);
        laserCd = false;
    }
    private void LaserAttack()
    {
        //RaycastHit2D hit2D = Physics2D.Raycast(transform.position, -transform.up);
        //Debug.DrawLine(transform.position, hit2D.point);
        //laserHit.position = hit2D.point;
        //line.SetPosition(0, transform.position);
        //line.SetPosition(1, laserHit.position);

        Instantiate(laser, transform.position, transform.rotation);
        laserCd = true;
    }
    private void Move()
    {
        transform.position = Vector2.MoveTowards(transform.position,
          new Vector2(player.position.x, transform.position.y), speed * Time.deltaTime);
    }
    IEnumerator TeethColdDown()
    {
        yield return new WaitForSeconds(3f);
        cd = false;
    }
    private void SentTeeth()
    {
       
        Instantiate(leftTeeth, teethPointLeft[0].position, teethPointLeft[0].rotation);
        Instantiate(leftTeeth, teethPointLeft[1].position, teethPointLeft[1].rotation);
        Instantiate(rightTeeth, teethPointRight[0].position, teethPointRight[0].rotation);
        Instantiate(rightTeeth, teethPointRight[1].position, teethPointRight[1].rotation);
        cd = true;

        //for (int i = 0; i < 1; i++)
        //{
        //    Instantiate(rightTeeth, teethPointRight[i].position, teethPointRight[i].rotation);
        //}



    }
}
