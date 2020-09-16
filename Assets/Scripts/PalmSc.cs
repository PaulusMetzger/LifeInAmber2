using UnityEngine;

public class PalmSc : MonoBehaviour
{
    Animator anim;
    public GameObject drop1; // отпечаток смолы который на листе
    
    GameObject Slepok;

    Vector3 coord;
    bool action;
    bool single;
    bool once;
    bool moveDown, moveUp;
    float step = 1;
    float dist;
    Vector3 point;

    void Start()
    {
        drop1 = GameObject.Find("slepok");
        anim = GetComponent<Animator>();
        
        action = true;
       
        single = ObjectManager.activity;

        moveDown = false;
        moveUp = false;
        
    }

    void Update()
    {
       
        if (moveDown)
        {
           
            dist = Vector3.Distance(coord, point);
            if(dist>=0.1f)drop1.transform.localPosition = Vector3.MoveTowards(drop1.transform.localPosition, point, step * Time.deltaTime);
        }
        if (moveUp)
        {
            drop1.transform.localPosition = coord;
        }


        if (ObjectManager.activity!=single)//когда нажата кнопка
        {
            KlikFunction();
            single = ObjectManager.activity;            
        }   
    }

    public void KlikFunction() //функция которая обеспечивает действие пальмы при нажатии на среднюю кнопку
    {        
        if (action == true)
        {
            coord = drop1.transform.localPosition;
            point = new Vector3(coord.x, coord.y - 1, coord.z);
            anim.SetTrigger("fast");            
            moveDown = true;
            moveUp = false;
            action = false;            
        }
        else if (action == false)
        {
            action = true;
            moveDown =false;
            moveUp = true;                  
        }        
    }
}


