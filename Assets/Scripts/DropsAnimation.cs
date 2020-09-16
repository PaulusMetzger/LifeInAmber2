using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropsAnimation : MonoBehaviour

{
    Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        StartCoroutine(SpeeReg());
        Debug.Log("куратина запустилась");
    }
    IEnumerator SpeeReg()
    {
        yield return new WaitForSeconds(Random.Range(1.5f, 5f));
        anim.SetBool("speed", !anim.GetBool("speed"));
        Debug.Log("куратина запустилась");
        StartCoroutine(SpeeReg());
    }

}
