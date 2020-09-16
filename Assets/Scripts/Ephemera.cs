using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ephemera : MonoBehaviour
{
    Animator anim;
    Transform Heimat;
    public float speedE;
    float dist;
    bool x, once;    
    int eDir1;
    Vector3 startPos;
    Quaternion initRotation;
    ParticleSystem[] PS;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        eDir1 = Random.Range(0, 10);
        x = ObjectManager.activity;
        Heimat = transform.parent.transform;
        startPos = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        initRotation = transform.rotation;
        PS = Heimat.GetComponentsInChildren<ParticleSystem>();
        foreach (ParticleSystem partS in PS)
        {
            var emission = partS.emission;
            emission.enabled = false;
        }
    }
    IEnumerator FlyE()
    {
        yield return new WaitForSeconds(0.5f);
        //once = true;
    }
    void Returing()
    {
        transform.LookAt(Heimat, transform.up);
        //Vector3 targetDirection = Heimat.position - transform.position;
        //transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(targetDirection, Vector3.up), Time.deltaTime * 10);
    }

    // Update is called once per frame
    void Update()
    {       
        if (x != ObjectManager.activity) // нажатие кнопки, полет по кругу
        {            
            if (once)
            {
                anim.SetBool("flyUp", true);
                StartCoroutine(FlyE());
                once = false;
                foreach (ParticleSystem partS in PS)
                {
                    var emission = partS.emission;
                    emission.enabled = true;
                }
            }
           transform.position += transform.forward * speedE * Time.deltaTime;
            if (eDir1 % 2 == 0) transform.Rotate(Vector3.up * speedE / Random.Range(7f, 10f));
            else transform.Rotate(Vector3.down * speedE / Random.Range(7f, 10f));
        }
        else
        {
            dist = Vector3.Distance(transform.position, Heimat.position);
            Debug.Log("dist  " + dist + "once" + once);
            if (dist <= 0.1f)
            {
                if (!once)
                {
                    anim.SetBool("flyUp", false);                   
                    transform.position = Heimat.position;
                    transform.rotation = initRotation;
                    eDir1 = Random.Range(0, 10);
                    foreach (ParticleSystem partS in PS)
                    {
                        var emission = partS.emission;
                        emission.enabled = false;
                    }
                    once = true;
                }               
            }
            else
            {
                Returing();
                transform.position += transform.forward * speedE * Time.deltaTime;                
            }
        }
    }
}