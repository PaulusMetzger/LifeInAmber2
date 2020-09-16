using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cerambicidae : MonoBehaviour
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
            anim.SetBool("action",true);
            StartCoroutine(DelayAction());
        }
    }
    IEnumerator DelayAction()
    {
        yield return new WaitForSeconds(1);
        anim.SetBool("action", false);
        x = ObjectManager.activity;
    }
}
