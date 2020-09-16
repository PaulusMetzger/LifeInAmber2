using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BriumSporesPS : MonoBehaviour
{
    ParticleSystem sporesPS;
    public float delay=1;
    bool x;
    bool emissionMode;
    // Start is called before the first frame update
    void Start()
    {
        sporesPS = GetComponent<ParticleSystem>();
        x = ObjectManager.activity;
        emissionMode = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (x != ObjectManager.activity)
        {
            if (emissionMode)
            {
                StartCoroutine(Begining());               
            }
            else
            {
                StartCoroutine(Ending());                
            }
            emissionMode = !emissionMode;
            x = ObjectManager.activity;

        }
    }

    IEnumerator Begining()
    {
        yield return new WaitForSeconds(delay);
        var emission = sporesPS.emission;
        emission.enabled = true;
        sporesPS.Play();
    }
    IEnumerator Ending()
    {
        yield return new WaitForSeconds(1);
        var emission = sporesPS.emission;
        emission.enabled = false;
        sporesPS.Stop();
    }
}
