using UnityEngine;

public class ResinActivity : MonoBehaviour
{
    Transform[] drops;
    
    private void Start()
    {
        drops= GetComponentsInChildren<Transform>();
       
        //Debug.Log("drops.Length"+drops.Length);
    }

    void Update()
    {
        if (ObjectManager.activity)
        {
            for (int i = 1; i < drops.Length; i++)
            {
                drops[i].gameObject.SetActive(true);
            }
        }
        else if (!ObjectManager.activity)
        {
            for (int i = 1; i < drops.Length; i++)
            {
                drops[i].gameObject.SetActive(false);
            }
        }
    }
   
}
