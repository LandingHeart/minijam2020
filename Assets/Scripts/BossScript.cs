﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossScript : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform player;
    private float speed = 10f;
    public float maxHp = 50f;
    private float currHp;

    public GameObject leftTeeth;
    public GameObject rightTeeth;
    public Transform[] teethPointLeft;// 2 teeth
    public Transform[] teethPointRight;// 2 teeth
    public SpriteRenderer sr;
    
    public float movementCD = 10f;
    public float fireRate = 0.2f;
    public float nextFire;
    private bool cd = false;
    
    public GameObject laser;
    private bool laserCd = false;

    public GameObject greenTeeth;
    float dist = 0;

    public float cdTime = 1f;
    void Start()
    {
        //transform.position = new Vector2(player.position.x, transform.position.y);
        currHp = maxHp;
        sr = GetComponentInChildren<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {

        Attack();
        Move();
        if(currHp <= 300)
        {
            sr.color = new Color(255, 0, 0);
            speed = 15f;
            LaserScript.bulletSpeed = 60f;

        }
        //transform.position = Vector2.MoveTowards(transform.position,
        //           new Vector2(player.position.x, transform.position.y), speed * Time.deltaTime);
    }
    private void Attack() {
        movementCD -= Time.time;
      
        if (player != null)
        {
            dist = player.position.x - transform.position.x;
        }

        if (dist < 0)
        {
            dist = dist * -1;

        }
        if (dist <= 0f)
        {
            if (cd == false)
            {
                SentTeeth();
                StartCoroutine(TeethColdDown());
            }
        }
        if (dist <= 2f)
        {
            greenTeeth.SetActive(true);
        }
        else
        {
            greenTeeth.SetActive(false);
        }

        if (laserCd == false)
        {
            LaserAttack();
            StartCoroutine(MyLaserCd());
        }
    }
    IEnumerator MyLaserCd() {
        yield return new WaitForSeconds(cdTime);
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
        if(player != null)
        {
            transform.position = Vector2.MoveTowards(transform.position,
  new Vector2(player.position.x, transform.position.y), speed * Time.deltaTime);
        }

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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("MyRedBullet"))
        {
            
            TakeDamage(10f);
            Debug.Log("take damge red");
        }
        if (collision.gameObject.CompareTag("MyBlueBullet"))
        {
          
            TakeDamage(10f);
            Debug.Log("take damge blue");
        }
        if (collision.gameObject.CompareTag("MyGreenBullet"))
        {
            TakeDamage(10f);
           
            Debug.Log("take damge g");
        }
        if (collision.gameObject.CompareTag("MyWhiteBullet"))
        {
           
            TakeDamage(10f);
            Debug.Log("take damge w");
        }
    }
    private void TakeDamage(float damage) {
        currHp -= damage;
        sr.color = new Color(255, 0, 0);
        StartCoroutine(resetColor());
        if(currHp <= 0)
        {   
            Destroy(gameObject, 0.1f);
        }
    }
    IEnumerator resetColor() {
        yield return new WaitForSeconds(0.1f);
        sr.color = new Color(255, 255, 255);
    }
}
