using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    // Start is called before the first frame update
    public float currHp;
    public float maxHp = 100f;
    PlayerAim playerAim;
    void Start()
    {
        currHp = maxHp;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("MyRedBullet"))
        {

            TakeDamage(playerAim.bulletDamge);
        }
        if (collision.gameObject.CompareTag("MyGreenBullet"))
        {
            TakeDamage(playerAim.bulletDamge);
        }
        if (collision.gameObject.CompareTag("MyBlueBullet"))
        {
            TakeDamage(playerAim.bulletDamge);
        }
    }
    private void TakeDamage(float damage) {
        currHp -= damage;

        if(currHp <= 0f)
        {
            Destroy(gameObject);
        }
    }
}
