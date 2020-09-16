using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BriumSc : MonoBehaviour
{
    Animator anim;
    bool x;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        x = ObjectManager.activity;
    }

    // Update is called once per frame
    void Update()
    {
        if (x != ObjectManager.activity)
        {
            anim.SetBool("open", !anim.GetBool("open"));
            x = ObjectManager.activity;
        }
    }
}
