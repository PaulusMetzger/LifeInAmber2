using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreodontSc : MonoBehaviour
{
    Animator anim;
    bool g, regG;
    public float speedC = 5;
    public float circleSize = 2;
    float dist;
    int gast2 = 2; // регуляция перемещения по или против часовой стрелки
    Transform Log; //точка возврата модели   
    bool single;
    bool RotBool = true;
    Vector3 startPosition;

    void Start()
    {
        g = ObjectManager.activity;
        anim = GetComponent<Animator>();       
        Log = transform.parent;        
        startPosition = new Vector3(transform.localPosition.x, transform.localPosition.y, transform.localPosition.z);
        single = true;
    }
    
    void Update()
    {
        dist = Vector3.Distance(transform.position, Log.TransformPoint(startPosition.x, startPosition.y, startPosition.z));
        if (g != ObjectManager.activity)// запуск обычной прогулки
        {
            if (single) // выполняется однократно
            {
                RotBool = true;               
                anim.SetTrigger("go"); 
                single = false;
            }
            // выполняется каждый кадр
            transform.position += transform.forward * speedC * Time.deltaTime;
            if (gast2 % 2 == 0) transform.Rotate(Vector3.up * speedC / Random.Range(circleSize/2, circleSize));
            else transform.Rotate(Vector3.down * speedC / Random.Range(circleSize/2, circleSize));
        }
        else //запуск возвращения на точку
        {
            if (dist <= 0.1f)  //пришел на точку
            {
                if (!single)
                {
                    anim.SetBool("run", false);                   
                    transform.position = Log.TransformPoint(startPosition.x, startPosition.y, startPosition.z);
                    regG = true;
                    single = true;
                }
            }

            else
            {
                anim.SetBool("run", true);
                Returning();
                transform.position += transform.forward * speedC * 2f * Time.deltaTime;
                if (regG)
                {
                    gast2 = Random.Range(0, 10);
                    regG = false;
                }
            }
        }
    }
    void Returning()
    {
        transform.LookAt(Log.TransformPoint(startPosition.x, startPosition.y, startPosition.z), transform.up);
    }
}