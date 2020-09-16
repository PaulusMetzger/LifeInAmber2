using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuercusLeavesSc : MonoBehaviour
{
    ParticleSystem leaves;
    bool x;
    // Start is called before the first frame update
    void Start()
    {
        leaves = GetComponent<ParticleSystem>();
        x = ObjectManager.activity;
        transform.Rotate(-90, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (x != ObjectManager.activity)
        {
            var emission = leaves.emission;
            emission.enabled = true;
        }
        else
        {
            var emission = leaves.emission;
            emission.enabled = false;
        }
    }
}
