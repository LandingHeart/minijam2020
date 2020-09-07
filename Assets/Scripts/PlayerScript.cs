﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    // Start is called before the first frame update
    public static float damage = 10f;
    [SerializeField]
    private float currHp;
    public float maxHp = 100;
    public enum myColors {RED, GREEN, BLUE, DEFAULT};
    public myColors currColors;
    public SpriteRenderer sr;
    public float timer;
    public GameObject mySprite;
    public HealthBar health;

    [SerializeField] public ColorBar redBar;
    [SerializeField] public ColorBar greenBar;
    [SerializeField] public ColorBar blueBar;
    public int red_bullets = 0;
    public int green_bullets = 0;
    public int blue_bullets = 0;

    void Start()
    {   //enum set curr color to default
        currColors = myColors.DEFAULT;
        currHp = maxHp;
        health.SetMaxHealth(maxHp);
        //get player sprite in children
        sr = GetComponentInChildren<SpriteRenderer>();
        timer = 0.0f;
    }
    // Update is called once per frame
    void Update()
    {
        ColorSwitch();
    }
    private void ColorSwitch() {
        //change with time
        //timer += Time.deltaTime;
        //timer = timer % 20;
        //if (timer < 10)
        //{
        //    sr.color = Color.red;
        //    currColors = myColors.RED;
        //}
        //else if (timer > 10 && timer < 15)
        //{
        //    sr.color = Color.blue;
        //    currColors = myColors.BLUE;
        //}
        //else if (timer > 15 && timer < 20)
        //{
        //    sr.color = Color.green;
        //    currColors = myColors.GREEN;
        //}

        // change with keys
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            sr.color = Color.red;
            currColors = myColors.RED;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            sr.color = Color.green;
            currColors = myColors.GREEN;
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            sr.color = Color.blue;
            currColors = myColors.BLUE;
        }


    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // //check collision by comparing the tags of object 
        // if (collision.gameObject.CompareTag("RedBullet"))
        // {
        //   if(currColors.Equals(myColors.BLUE))
        //     {
        //         TakeDamage(10f);
        //         Debug.Log(currColors + " color, and take red bullet damge: " + 10f);

        //     }
        //   if(currColors.Equals(myColors.GREEN))
        //     {
        //         TakeDamage(10f);
        //         Debug.Log(currColors + " color, and take green bullet damge: " + 10f);
        //     }
        // }
        // if (collision.gameObject.CompareTag("GreenBullet"))
        // {
        //     if (currColors.Equals(myColors.BLUE))
        //     {
        //         TakeDamage(10f);
        //         Debug.Log(currColors + " color, and take green bullet damge: " + 10f);
        //     }
        //     if (currColors.Equals(myColors.RED))
        //     {
        //         TakeDamage(10f);
        //         Debug.Log(currColors + " color, and take green bullet damge: " + 10f);
        //     }
        // }
        // if (collision.gameObject.CompareTag("BlueBullet"))
        // {
        //     if (currColors.Equals(myColors.RED))
        //     {
        //         TakeDamage(10f);
        //         Debug.Log(currColors + " color, and take blue bullet damge: " + 10f);

        //     }
        //     if (currColors.Equals(myColors.GREEN))
        //     {
        //         TakeDamage(10f);
        //         Debug.Log(currColors + " color, and take blue bullet damge: " + 10f);
        //     }
        // }

        if (collision.gameObject.CompareTag("Laser"))
        {
            TakeDamage(10f);
            // Debug.Log("collided with laser" + "Health now:" + currHp);
        }
        if (collision.gameObject.CompareTag("Teeth")) {
            // Debug.Log("collided with teeth");
            TakeDamage(5f);
        }

    }

    public void TakeDamage(float damage)
    {
        currHp -= damage;
        mySprite.SetActive(true);
        StartCoroutine(resetColor());
        health.setHealth(currHp);
        if (currHp <= 0)
        {
            //play animation
            Debug.Log("player die");
            Destroy(gameObject);
        }
    }

    public void TakeDamage(float damage, myColors color)
    {
        Debug.Log("player taking damage " + color + ", current self color " + currColors);
        if(color == currColors){
           // absorb bullet
           Absorb(color, false);
        }else{
            currHp -= damage;
            mySprite.SetActive(true);
            StartCoroutine(resetColor());
            health.setHealth(currHp);
        }
        
        if (currHp <= 0)
        {
            //play animation
            Debug.Log("player die");
         
            Destroy(gameObject);
        }
    }

    public void TakeDamage(float damage, myColors color, bool isMinion){
        if(color == currColors){
           // absorb bullet
           Absorb(color, isMinion);
        }else{
            currHp -= damage;
            mySprite.SetActive(true);
            StartCoroutine(resetColor());
            health.setHealth(currHp);
        }
        
        if (currHp <= 0)
        {
            //play animation
            Debug.Log("player die");
         
            Destroy(gameObject);
        }
    }

    IEnumerator resetColor()
    {
        yield return new WaitForSeconds(0.1f);
        mySprite.SetActive(false);
    }

    public void Absorb(myColors color, bool isMinion){
        int green_amount = 1000;
        if(isMinion){
            green_amount = 500;
        }
        switch(color){
            case myColors.RED:
                red_bullets += 1;
                redBar.setColorBullets(red_bullets);
                break;
            case myColors.GREEN:
                green_bullets += green_amount;
                greenBar.setColorBullets(green_bullets);
                break;
            case myColors.BLUE:
                blue_bullets += 1;
                blueBar.setColorBullets(blue_bullets);
                break;
            default:
                break;
        }
    }

    public void useAColorBullet(myColors color){
        switch(color){
            case myColors.RED:
                red_bullets -= 1;
                redBar.setColorBullets(red_bullets);
                break;
            case myColors.GREEN:
                green_bullets -= 50;
                greenBar.setColorBullets(green_bullets);
                break;
            case myColors.BLUE:
                blue_bullets -= 1;
                blueBar.setColorBullets(blue_bullets);
                break;
            default:
                break;
        }
    }
}
