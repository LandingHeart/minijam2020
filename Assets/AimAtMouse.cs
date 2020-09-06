using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimAtMouse : MonoBehaviour
{
    private float fireRate = 0.1f;
    private float nextFire;

    public GameObject flameThrowerPoint; 

    void Start()
    {
        flameThrowerPoint.SetActive(false);

    }
    // Update is called once per frame
    void Update()
    {
        if (ParticleScript.on)
        {
            flameThrowerPoint.SetActive(true);
        }
        if(ParticleScript.on == false) {
            flameThrowerPoint.SetActive(false);
        }

       

        Vector3 mousepos = Input.mousePosition;
        mousepos = Camera.main.ScreenToWorldPoint(mousepos);

        Vector2 dir = new Vector2(mousepos.x - transform.position.x, mousepos.y - transform.position.y);

        transform.up = dir;
       
    }
 
}
