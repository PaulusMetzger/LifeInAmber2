using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagnoliaPS : MonoBehaviour
{
    ParticleSystem PaSy;
    bool reg;
    
    private void Start()
    {
        PaSy = GetComponent<ParticleSystem>();
        reg = ObjectManager.activity;
    }
    IEnumerator Begining()
    {
        yield return new WaitForSeconds(5f);
        var emission = PaSy.emission;
        emission.enabled = true;
    }
    IEnumerator Ending()
    {
        yield return new WaitForSeconds(5f);
        var emission = PaSy.emission;
        emission.enabled = false;
    }
    
    private void Update()
    {
        if (reg!= ObjectManager.activity)
        {
            StartCoroutine(Begining());
        }
       else if(reg== ObjectManager.activity)
        {
            StartCoroutine(Ending());
        }
    }
}
