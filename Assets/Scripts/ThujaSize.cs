using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThujaSize : MonoBehaviour
{
    Animator anim;
    bool x;
    int i;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        x = ObjectManager.activity;
        i = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (x != ObjectManager.activity)
        {
            
            if (i==0) anim.SetTrigger("large");
            else anim.SetTrigger("small");
            if(i > 0) i = 0;
            i++;
            x = ObjectManager.activity;
            Debug.Log("i " + i);
        }       
    }
}
