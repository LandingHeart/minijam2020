using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    // Start is called before the first frame update
    public static float damage = 10f;
    private float currHp;
    public float maxHp = 500;
    public enum myColors { RED, GREEN, BLUE, DEFAULT};
    public myColors currColors;
    public SpriteRenderer sr;
    public float timer;
  
    void Start()
    {   //enum set curr color to default
        currColors = myColors.DEFAULT;
        currHp = maxHp;
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
            sr.color = Color.blue;
            currColors = myColors.BLUE;
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            sr.color = Color.green;
            currColors = myColors.GREEN;
        }


    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //check collision by comparing the tags of object 
        if (collision.gameObject.CompareTag("RedBullet"))
        {
          if(currColors.Equals(myColors.BLUE))
            {
                TakeDamage(10f);
                Debug.Log(currColors + " color, and take red bullet damge: " + 10f);

            }
          if(currColors.Equals(myColors.GREEN))
            {
                TakeDamage(10f);
                Debug.Log(currColors + " color, and take green bullet damge: " + 10f);
            }
        }
        if (collision.gameObject.CompareTag("GreenBullet"))
        {
            if (currColors.Equals(myColors.BLUE))
            {
                TakeDamage(10f);
                Debug.Log(currColors + " color, and take green bullet damge: " + 10f);
            }
            if (currColors.Equals(myColors.RED))
            {
                TakeDamage(10f);
                Debug.Log(currColors + " color, and take green bullet damge: " + 10f);
            }
        }
        if (collision.gameObject.CompareTag("BlueBullet"))
        {
            if (currColors.Equals(myColors.RED))
            {
                TakeDamage(10f);
                Debug.Log(currColors + " color, and take blue bullet damge: " + 10f);

            }
            if (currColors.Equals(myColors.GREEN))
            {
                TakeDamage(10f);
                Debug.Log(currColors + " color, and take blue bullet damge: " + 10f);
            }
        }
    }

    private void TakeDamage(float damage)
    {
        currHp -= damage;
      
        if (currHp <= 0)
        {
            //play animation
            Destroy(gameObject, 3f);
        }
    }   
}
