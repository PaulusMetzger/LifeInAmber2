using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FitotelmatSc : MonoBehaviour
{
    Animator anim;
    bool a;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        a = ObjectManager.activity;
    }

    // Update is called once per frame
    void Update()
    {
        if(a!= ObjectManager.activity)
        {
            anim.SetBool("Rotation", !anim.GetBool("Rotation"));
            a = !a;
        }
    }
}
