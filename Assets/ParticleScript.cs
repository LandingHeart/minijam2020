using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleScript : MonoBehaviour
{
    // Start is called before the first frame update
    ParticleSystem ps;
    float time = 5;
    public static bool on = false;
    void Start()
    {
        ps = GetComponent<ParticleSystem>();
        ps.playOnAwake = false;
    }

    // Update is called once per frame
    void Update()
    {

       
        if (Input.GetKeyDown(KeyCode.F)){
            ps.Play();
            on = true;
        }


        if (on)
        {
            time -= Time.time;
            if (time < 10f)
            {
                ps.Stop();
                on = false;
                time = 5;
            }
        }

    }
   
    private void OnParticleTrigger()
    {
        
    }
}
