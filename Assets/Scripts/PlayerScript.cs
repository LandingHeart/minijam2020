using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    // Start is called before the first frame update
    public static float damage = 10f;
    private float currHp;
    public float maxHp = 1000;
    public SpriteRenderer sr;
    void Start()
    {
        currHp = maxHp;

        //sr.color = new Color(0, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("EnemyBullet"))
        {
            //TakeDamage(EnemyScript.damage);
            Debug.Log("Damge taken");
        }
    }
    private void TakeDamage(float damage)
    {
        currHp -= damage;
        sr.color = Color.white;
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
        sr.color = new Color(245, 84, 0);

    }
}
