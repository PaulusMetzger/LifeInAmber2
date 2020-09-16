using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonFly : MonoBehaviour
{
    Animator anim;    
    public float speedDF;
    public float circleSize;
    bool once;
    bool regDf, single;
    float df;
    int df2;
    Transform Log;
    bool x;

    Vector3 startPosition;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        df = Random.Range(0f, 10f);
        single = true;
        startPosition = new Vector3(transform.localPosition.x, transform.localPosition.y, transform.localPosition.z);
        Log = transform.parent.gameObject.transform;
        x = ObjectManager.activity;
    }

    // Update is called once per frame
    void Update()
    {
        
        if (x!=ObjectManager.activity) //полет стрекозы по кругу по нажатию на кнопку
        {
            if (single)
            {
                anim.SetBool("Fly", true);
                StartCoroutine(FlyDF());
                single = false;
            }
            
            if (once)
            {
               transform.position += transform.forward * speedDF * Time.deltaTime;
                df2 = (int)df;
                if (df2 % 2 == 0) transform.Rotate(Vector3.up * circleSize / Random.Range(2f, 4f));
                else transform.Rotate(Vector3.down * circleSize / Random.Range(2f, 4f));
            }
        }
        else
        {
            once = false;
            float dist = Vector3.Distance(transform.position, Log.TransformPoint(startPosition.x, startPosition.y, startPosition.z));
            if (dist <= 0.1f)
            {
                anim.SetBool("Fly", false);
                transform.position = Log.TransformPoint(startPosition.x, startPosition.y, startPosition.z);
                transform.rotation = Quaternion.Euler(0f, 90f, 0f);
                regDf = true;//переменная которая обеспечивает изменение напраления полета по кругу
                single = true;
            }
            else
            {
                Returing();
                transform.position += transform.forward * speedDF * Time.deltaTime;
            }
        }
    }
    IEnumerator FlyDF()
    {
        yield return new WaitForSeconds(0.5f);
        once = true;       
    }
    void Returing()
    {
        transform.LookAt(Log.TransformPoint(startPosition.x, startPosition.y, startPosition.z), Vector3.up);
        if (regDf)
        {
            df = Random.Range(0f, 10f);
            regDf = false;
        }
    }
}
