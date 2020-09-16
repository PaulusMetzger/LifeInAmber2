using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Termit : MonoBehaviour
{
    Animator anim;
    Transform term;
    bool x;
    bool once, waitBeforeFly;
    bool tReg; //чтобы менять направление вращения
    float dist;
    int d2;
    Transform homeT;
    public float speedGoT=3;
    public float speedFlyT=5;
    Vector3 startPos;
    Quaternion initRotation;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        term = GetComponent<Transform>();
        homeT = transform.parent.transform;
        d2 = Random.Range(0, 10);
        startPos = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        initRotation = transform.rotation;
        x = ObjectManager.activity;
        tReg = true;
        once = true;
        waitBeforeFly = false;
    }
    IEnumerator FlyT()
    {
        yield return new WaitForSeconds(0.5f);
        waitBeforeFly = true;
    }
    void Returing()
    {
        Vector3 targetDirection = homeT.position - transform.position;
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(targetDirection, Vector3.up), Time.deltaTime * 10);        
    }

    // Update is called once per frame
    void Update()
    {
        if (x != ObjectManager.activity) // нажатие кнопки, полет по кругу
        {
            if (once)
            {
                anim.SetBool("walk", false);
                anim.SetBool("FlyT", true);               
                StartCoroutine(FlyT());
                once = false;               
            }
            // движение полета включается с задержкой на пол секунды
            if (waitBeforeFly)
            {
                transform.position += transform.forward * speedFlyT * Time.deltaTime;
                if (d2 % 2 == 0) transform.Rotate(Vector3.up * speedFlyT / Random.Range(7f, 10f));
                else transform.Rotate(Vector3.down * speedFlyT / Random.Range(7f, 10f));
            }            
        }
        else
        {
            dist = Vector3.Distance(transform.position, homeT.position);
            Debug.Log("dist  " + dist + "once" + once);
            if (dist <= 0.1f)
            {
                if (!once)
                {
                    anim.SetBool("walk", false);
                    anim.SetBool("FlyT", false);
                    transform.position = homeT.position;
                    transform.rotation = initRotation;
                    d2 = Random.Range(0, 10);
                    once = true;
                    tReg = true;
                    waitBeforeFly = false;
                }
            }
            else
            {
                Returing();
                transform.position += transform.forward * speedGoT * Time.deltaTime;
                if (tReg)
                {
                    anim.SetBool("FlyT", false);
                    anim.SetBool("walk", true);
                    tReg = false;
                    waitBeforeFly = false;
                }               
            }
        }
    }
}