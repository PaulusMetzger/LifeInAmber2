using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gastornis : MonoBehaviour
{
    Animator anim;   
    bool g, regG;   
    public float speedG=5;
    public float circleSize = 2;
    float dist;
    int gast2=2; // регуляция перемещения по или против часовой стрелки
    Transform Nest; //точка возврата модели
    AudioSource Kar;
    bool Korut; // однократный запуск крика
    bool single;
    bool RotBool = true;
    Vector3 startPosition;
    Slider soundSlider;

    void Start()
    {
        g = ObjectManager.activity;
        anim = GetComponent<Animator>();        
        Kar = GetComponent<AudioSource>();
        soundSlider = GameObject.Find("SoundSlider").GetComponent<Slider>();
        //точка рассчитывается относительно второго объекта префаба
        Nest = transform.parent.gameObject.transform.GetChild(1).transform; 
        Korut = true;//переменная чтобы пение птицы запускалось однократно
        startPosition = new Vector3(transform.localPosition.x, transform.localPosition.y, transform.localPosition.z);
        single = true;
    }
    IEnumerator Anoth()
    {
        yield return new WaitForSeconds(1.5f);
        Kar.Stop();
        anim.SetBool("golos", false);
    }
    IEnumerator Golos()
    {
        yield return new WaitForSeconds(Random.Range(3f, 5f));
        anim.SetBool("golos", true);
        Kar.Play();
        StartCoroutine(Anoth());
    }

    // Update is called once per frame
    void Update()
    {
        Kar.volume = soundSlider.value;
        dist = Vector3.Distance(transform.position, Nest.TransformPoint(startPosition.x, startPosition.y, startPosition.z));
        if (g!=ObjectManager.activity)// запуск обычной прогулки
        {
            if (single) // выполняется однократно
            {
                RotBool = true;
                StopCoroutine(Golos());
                anim.SetBool("golos", false);
                anim.SetBool("go", true);
                Kar.Pause();
                Korut = true;               
                single = false;
            }
            // выполняется каждый кадр
            transform.position += transform.forward * speedG * Time.deltaTime;
            if (gast2 % 2 == 0) transform.Rotate(Vector3.up * speedG / Random.Range(circleSize, circleSize * 2f));
            else transform.Rotate(Vector3.down * speedG / Random.Range(circleSize, circleSize * 2f));
        }
        else //запуск возвращения на точку
        {           
            //Debug.Log(dist + "   dist");
            if (dist <= 0.1f)  //пришел на точку
            {
                if (!single)
                {
                    anim.SetBool("run", false);
                    anim.SetBool("go", false);
                    transform.position = Nest.TransformPoint(startPosition.x, startPosition.y, startPosition.z);
                    regG = true;
                    if (Korut)
                    {
                        StartCoroutine(Golos());
                        Korut = false;
                    }
                    single = true;
                }               
            }

            else
            {  
                anim.SetBool("go", true);
                anim.SetBool("run", true);               
                Returning();
                transform.position += transform.forward * speedG * 2f * Time.deltaTime;                
                if (regG)
                {
                    gast2 = Random.Range(0, 10);
                    regG = false;
                }
            }
        }
    }
    void Returning()
    {
        transform.LookAt(Nest.TransformPoint(startPosition.x, startPosition.y, startPosition.z), Vector3.up);       
    }
}