using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Spider : MonoBehaviour
{
    Animator animS;
    public GameObject Web;
    Transform spiderT;
    bool rul, rul1;    
    float dist;
    
    void Start()
    {
        animS = GetComponent<Animator>();
        spiderT = GetComponent<Transform>();
        rul = false;
        rul1 = false;
        StartCoroutine(Waking());
        StartCoroutine(GoAway());       
    }
   
    void Update()
    {
        if (!ObjectManager.activity&&!animS.GetBool("go"))
        {
            animS.SetTrigger("angst");
            ObjectManager.activity = true;
        }
        if (rul)
        {   //выход паука на сцену        
            spiderT.position = Vector3.MoveTowards(spiderT.position, Web.transform.TransformPoint(0.1f, 3.5f, 0),  4 * Time.deltaTime);
            dist = Vector3.Distance(spiderT.transform.position, Web.transform.TransformPoint(0.1f, 3.5f, 0));
            if (dist <= 0.2)
            {
                animS.SetBool("go", false);
                spiderT.transform.rotation = Web.transform.rotation;
                spiderT.transform.Rotate(90f, 0f, 0f);
                rul = false;                
            }
        }
        if (rul1)
        {
           
            spiderT.transform.position += spiderT.transform.forward * 4 * Time.deltaTime;
            dist = Vector3.Distance(spiderT.transform.position, Web.transform.TransformPoint(0.11f, 1.1f, -33.3f)); //это когда паук убегает вдаль
            if (dist <= 0.2)
            {
                animS.SetBool("go", false);
                rul1 = false;                
            }
        }
    }
    IEnumerator Waking()
    {
        yield return new WaitForSeconds(5f);
        spiderT.LookAt(Web.transform.TransformPoint(0.11f, 1.1f, 0.71f));
        animS.SetBool("go", true);
        rul = true;
    }
    IEnumerator GoAway()
    {
        yield return new WaitForSeconds(68f);       
        animS.SetBool("go", true);
        spiderT.LookAt(Web.transform.TransformPoint(0.11f, 1.2f, 12.7f));
        rul1 = true;
    }

}
