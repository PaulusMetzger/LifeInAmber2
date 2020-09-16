using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindZoneRotation : MonoBehaviour
{
    Quaternion newRotation;
    public float step=1;
   
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(WindRotation());       
    }
    IEnumerator WindRotation()
    {
        yield return new WaitForSeconds(5);
        newRotation = Quaternion.Euler(transform.rotation.x, Random.Range(0,180), transform.rotation.z);
        StartCoroutine(WindRotation());


    }
    // Update is called once per frame
    void Update()
    {
        if (newRotation != null)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, newRotation, step * Time.deltaTime);
        }
    }
}
