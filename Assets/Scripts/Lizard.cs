using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lizard : MonoBehaviour
{
    Animator anim;
    bool lizReg,once;
    public float speedLiz = 2;
    public float rotationLiz = 2;
    Transform lizHome;
    Vector3 startPos;
    float dist;
    int lizCircle = 2;
    public GameObject tail;
    bool problem;
    bool returnHome;
    GameObject newTail;

    void Start()
    {
        anim = GetComponent<Animator>();
        lizReg = ObjectManager.activity;
        once = true;
        lizHome = transform.parent.transform;
        startPos = new Vector3(lizHome.position.x, lizHome.position.y, lizHome.position.z);
        problem = true;
        returnHome = false;
    }

    // Update is called once per frame
    void Update()
    {
       if(lizReg!= ObjectManager.activity)
        {
            //пробежка по кругу
            if (once)
            {
                anim.SetBool("run", true);
                once = false;
            }
            transform.position += transform.forward * speedLiz * Time.deltaTime;
            if (lizCircle % 2 == 0) transform.Rotate(Vector3.up, rotationLiz * Time.deltaTime);
            else transform.Rotate(Vector3.up, -rotationLiz * Time.deltaTime);
        }
        else
        {
            dist = Vector3.Distance(transform.position, lizHome.position);
           
            if (dist < 0.1f) // ящерица дома
            {
                if (!once)
                {
                    anim.SetBool("run", false);              
                    transform.position = lizHome.position;
                    transform.GetChild(2).gameObject.SetActive(true);
                    problem = true;
                    returnHome = false;
                    lizCircle = Random.Range(0, 10);
                    once = true;
                }

            }
            else  // ящерица не дома
            {
                if (problem)
                {
                    TailProblem();
                    problem = false;
                }
                if (returnHome)
                {
                    Returning();
                    transform.position += transform.forward * speedLiz * Time.deltaTime;
                }
            }
        }
    }

    void TailProblem()
    {
        anim.SetBool("tail", true);
        transform.GetChild(2).gameObject.SetActive(false); // исчезновение хвоста
        newTail=Instantiate(tail, Vector3.zero, Quaternion.identity);//добавление префаба с хвостом
        newTail.transform.position = transform.position;
        newTail.transform.rotation = transform.rotation;
        StartCoroutine(WaitAnimation());
        anim.SetBool("tail", false);
        anim.SetBool("run", true);
    }
    void Returning()
    {
        Vector3 targetDirection = lizHome.position - transform.position;
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(targetDirection, Vector3.up), Time.deltaTime*2);
    }
    IEnumerator WaitAnimation()
    {
        yield return new WaitForSeconds(3f);       
        returnHome = true;
        Destroy(newTail, 3);
    }

}
