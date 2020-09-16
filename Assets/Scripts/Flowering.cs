
using System.Collections;
using UnityEngine;

public class Flowering : MonoBehaviour
{
    public bool flo;
    Animator flow;
    // Start is called before the first frame update
    void Start()
    {
        flow = GetComponent<Animator>();
        flo = ObjectManager.activity;
    }

    // Update is called once per frame
    void Update()
    {
        
        if (flo!= ObjectManager.activity)
        {
            flow.SetBool("Flow", true);
        }
        else
        {
            flow.SetBool("Flow", false);
        }
    }
}
