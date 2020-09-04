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
    {
        currColors = myColors.DEFAULT;
        currHp = maxHp;
        sr = GetComponentInChildren<SpriteRenderer>();
        timer = 0.0f;
    }
    // Update is called once per frame
    void Update()
    {
        ColorSwitch();
    }
    private void ColorSwitch() {
        timer += Time.deltaTime;
        if (timer > 5 && timer < 10)
        {
            sr.color = Color.red;
            currColors = myColors.RED;
        }
        else if (timer > 10 && timer < 15)
        {
            sr.color = Color.blue;
            currColors = myColors.BLUE;
        }
        else if (timer > 15 && timer < 20)
        {
            sr.color = Color.green;
            currColors = myColors.GREEN;
        }
        else
        {
            sr.color = Color.white;
            currColors = myColors.DEFAULT;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
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
        StartCoroutine(resetColor());
        if (currHp <= 0)
        {
            //play animation
            Destroy(gameObject, 3f);
        }
    }
    IEnumerator resetColor()
    {
        yield return new WaitForSeconds(0.1f);
    }
    
   
}
