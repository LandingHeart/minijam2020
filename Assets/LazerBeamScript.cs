using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LazerBeamScript : MonoBehaviour
{
    public Camera cam;
    public LineRenderer lineRenderer;
    public Transform firePoint;

    private Quaternion rotation;

    public GameObject startVFX;
    public GameObject endVFX;

    private List<ParticleSystem> particles = new List<ParticleSystem>();

    // Start is called before the first frame update
    void Start()
    {
        FillLists();
        DisableLazer();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Fire1")){
            EnableLazer();
        }

        if(Input.GetButton("Fire1")){
            UpdateLazer();
        }

        if(Input.GetButtonUp("Fire1")){
            DisableLazer();
        }

        RotateToMouse();
    }

    void EnableLazer(){
        lineRenderer.enabled = true;
        for(int i = 0; i < particles.Count; i++){
            particles[i].Play();
        }
    }

    void UpdateLazer(){
        var mousePos = (Vector2) cam.ScreenToWorldPoint(Input.mousePosition);
        lineRenderer.SetPosition(0, (Vector2)firePoint.position);
        startVFX.transform.position = (Vector2)firePoint.position;

        lineRenderer.SetPosition(1, mousePos);

        Vector2 direction = mousePos - (Vector2)transform.position;
        RaycastHit2D hit = Physics2D.Raycast((Vector2)transform.position, direction.normalized, direction.magnitude);

        if(hit){
            lineRenderer.SetPosition(1, hit.point);
            if(hit.collider.gameObject.tag == "Boss1"){
                BossScript bossScript = hit.collider.GetComponent<BossScript>();
                bossScript.TakeDamage(0.25f);
            }
        }

        endVFX.transform.position = lineRenderer.GetPosition(1);
    
    }

    void DisableLazer(){
        lineRenderer.enabled = false;
        for(int i = 0; i < particles.Count; i++){
            particles[i].Stop();
        }
    }

    void RotateToMouse(){
        Vector2 direction = cam.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        rotation.eulerAngles = new Vector3(0,0,angle);
        transform.rotation = rotation;
    }

    void FillLists(){
        for(int i = 0; i < startVFX.transform.childCount; i++){
            var ps = startVFX.transform.GetChild(i).GetComponent<ParticleSystem>();
            if(ps != null)
                particles.Add(ps);
        }

        for(int i = 0; i < endVFX.transform.childCount; i++){
            var ps = endVFX.transform.GetChild(i).GetComponent<ParticleSystem>();
            if(ps != null)
                particles.Add(ps);
        }
    }
}
