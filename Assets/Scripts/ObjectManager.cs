using UnityEngine;
using UnityEngine.UI;

public class ObjectManager : MonoBehaviour
{
    GameObject[] starPanel = new GameObject[15]; //не забыть изменить при добавлении новых мишеней
    public GameObject basePanel;

    AudioSource source;
    public AudioClip[] clips; //загрузка всех экскурсионных аудио
    public GameObject[] prefabs; //загрузка всех готовых префабов
    public static bool activity;
    GameObject activeObject;

    bool prefabRegulation;
    public Slider soundSlider;
    public GameObject AnnounsementPanel;

    
    void Start()
    {
        for (int i = 0; i < 15; i++) //не забыть изменить при добавлении новых мишеней
        {
            starPanel[i] = basePanel.transform.GetChild(i).transform.gameObject;
        }
        source = GetComponent<AudioSource>();
        activity = false;
        if (AnnounsementPanel != null) AnnounsementPanel.SetActive(true);
        prefabRegulation = true;
    }

    public void ImageTarget1(Transform ImagePos) //пальма
    {
        if (prefabRegulation)
        {
            Debug.Log("первая мишень найдена");
            starPanel[0].GetComponent<Image>().sprite = Resources.Load<Sprite>("UI/sunIconGreen");
            source.clip = clips[0];
            if (!source.isPlaying) source.Play();
            activeObject = Instantiate(prefabs[0], Vector3.zero, Quaternion.identity);
            //тут должно совпадать с координатами соответствующей мишени
            activeObject.transform.position = ImagePos.position;
            if (AnnounsementPanel != null) AnnounsementPanel.SetActive(false);
            prefabRegulation = false;
        }
        
         
        
    }
    public void ImageTarget2(Transform ImagePos) // янтарное дерево
    {
        if (prefabRegulation)
        {
            Debug.Log("вторая мишень найдена");
            starPanel[1].GetComponent<Image>().sprite = Resources.Load<Sprite>("UI/sunIconGreen");
            source.clip = clips[1];
            if (!source.isPlaying) source.Play();
            activeObject = Instantiate(prefabs[1], Vector3.zero, Quaternion.identity);
            //тут должно совпадать с координатами соответствующей мишени
            activeObject.transform.position = ImagePos.position;
            if (AnnounsementPanel != null) AnnounsementPanel.SetActive(false);
            prefabRegulation = false;
        }
        
                             
       
    }
    public void ImageTarget3(Transform ImagePos) // паук
    {
        if (prefabRegulation)
        {
            Debug.Log("третья мишень найдена");
            starPanel[2].GetComponent<Image>().sprite = Resources.Load<Sprite>("UI/sunIconGreen");
            source.clip = clips[2];
            if (!source.isPlaying) source.Play();
            activeObject = Instantiate(prefabs[2], Vector3.zero, Quaternion.identity);
            //тут должно совпадать с координатами соответствующей мишени
            activeObject.transform.position = ImagePos.position;
            if (AnnounsementPanel != null) AnnounsementPanel.SetActive(false);
            prefabRegulation = false;
        }   
    }
    public void ImageTarget4(Transform ImagePos) // фитотельмат
    {
        if (prefabRegulation)
        {
            Debug.Log("четвертая мишень найдена");
            starPanel[3].GetComponent<Image>().sprite = Resources.Load<Sprite>("UI/sunIconGreen");
            source.clip = clips[3];
            if (!source.isPlaying) source.Play();
            activeObject = Instantiate(prefabs[3], Vector3.zero, Quaternion.identity);
            //тут должно совпадать с координатами соответствующей мишени
            activeObject.transform.position = ImagePos.position;

            if (AnnounsementPanel != null) AnnounsementPanel.SetActive(false);
            prefabRegulation = false;
        }
        
           
    }
    public void ImageTarget5(Transform ImagePos) // магнолия
    {
        if (prefabRegulation)
        {
            Debug.Log("пятая мишень найдена");
            starPanel[4].GetComponent<Image>().sprite = Resources.Load<Sprite>("UI/sunIconGreen");
            source.clip = clips[4];
            if (!source.isPlaying) source.Play();

            activeObject = Instantiate(prefabs[4], Vector3.zero, Quaternion.identity);
            activeObject.transform.Rotate(90, 0, 0);
            //тут должно совпадать с координатами соответствующей мишени
            activeObject.transform.position = ImagePos.position;

            if (AnnounsementPanel != null) AnnounsementPanel.SetActive(false);
            prefabRegulation = false;
        }
        
           
    }
    public void ImageTarget6(Transform ImagePos) // стрекоза
    {
        if (prefabRegulation)
        {
            Debug.Log("шестая мишень найдена");
            starPanel[5].GetComponent<Image>().sprite = Resources.Load<Sprite>("UI/sunIconGreen");
            source.clip = clips[5];
            if (!source.isPlaying) source.Play();

            activeObject = Instantiate(prefabs[5], Vector3.zero, Quaternion.identity);
            //тут должно совпадать с координатами соответствующей мишени
            activeObject.transform.position = ImagePos.position;

            if (AnnounsementPanel != null) AnnounsementPanel.SetActive(false);
            prefabRegulation = false;
        }
        
           
    }
    public void ImageTarget7(Transform ImagePos) // гасторнис
    {
        if (prefabRegulation)
        {
            Debug.Log("седьмая мишень найдена");
            starPanel[6].GetComponent<Image>().sprite = Resources.Load<Sprite>("UI/sunIconGreen");
            source.clip = clips[6];
            if (!source.isPlaying) source.Play();

            activeObject = Instantiate(prefabs[6], Vector3.zero, Quaternion.identity);
            //тут должно совпадать с координатами соответствующей мишени
            activeObject.transform.position = ImagePos.position;

            if (AnnounsementPanel != null) AnnounsementPanel.SetActive(false);
            prefabRegulation = false;
        }
    }
    public void ImageTarget8(Transform ImagePos) // ящерица
    {
        if (prefabRegulation)
        {
            Debug.Log("восьмая мишень найдена");
            starPanel[7].GetComponent<Image>().sprite = Resources.Load<Sprite>("UI/sunIconGreen");
            source.clip = clips[7];
            if (!source.isPlaying) source.Play();

            activeObject = Instantiate(prefabs[7], Vector3.zero, Quaternion.identity);
            //тут должно совпадать с координатами соответствующей мишени
            activeObject.transform.position = ImagePos.position;

            if (AnnounsementPanel != null) AnnounsementPanel.SetActive(false);
            prefabRegulation = false;
        }
         
        
    }
    public void ImageTarget9(Transform ImagePos) // поденка
    {
        if (prefabRegulation)
        {
            Debug.Log("девятая мишень найдена");
            starPanel[8].GetComponent<Image>().sprite = Resources.Load<Sprite>("UI/sunIconGreen");
            source.clip = clips[8];
            if (!source.isPlaying) source.Play();

            activeObject = Instantiate(prefabs[8], Vector3.zero, Quaternion.identity);
            //тут должно совпадать с координатами соответствующей мишени
            activeObject.transform.Rotate(90, 0, 0);
            activeObject.transform.position = ImagePos.position;

            if (AnnounsementPanel != null) AnnounsementPanel.SetActive(false);
            prefabRegulation = false;
        }
       
                    
    }
    public void ImageTarget10(Transform ImagePos) // термит
    {
        if (prefabRegulation)
        {
            Debug.Log("десятая мишень найдена");
            starPanel[9].GetComponent<Image>().sprite = Resources.Load<Sprite>("UI/sunIconGreen");
            source.clip = clips[9];
            if (!source.isPlaying) source.Play();

            activeObject = Instantiate(prefabs[9], Vector3.zero, Quaternion.identity);
            //тут должно совпадать с координатами соответствующей мишени
            activeObject.transform.position = ImagePos.position;

            if (AnnounsementPanel != null) AnnounsementPanel.SetActive(false);
            prefabRegulation = false;
        }
        
           
    }
    public void ImageTarget11(Transform ImagePos) // креодонт
    {
        if (prefabRegulation)
        {
            Debug.Log("одинадцатая мишень найдена");
            starPanel[10].GetComponent<Image>().sprite = Resources.Load<Sprite>("UI/sunIconGreen");
            source.clip = clips[10];
            if (!source.isPlaying) source.Play();

            activeObject = Instantiate(prefabs[10], Vector3.zero, Quaternion.identity);
            //тут должно совпадать с координатами соответствующей мишени
            activeObject.transform.position = ImagePos.position;
            activeObject.transform.Rotate(90, 0, 0);

            if (AnnounsementPanel != null) AnnounsementPanel.SetActive(false);
            prefabRegulation = false;
        }
    }
    public void ImageTarget12(Transform ImagePos) // дуб мейера
    {
        if (prefabRegulation)
        {
            Debug.Log("двенадцатая мишень найдена");
            starPanel[11].GetComponent<Image>().sprite = Resources.Load<Sprite>("UI/sunIconGreen");
            source.clip = clips[11];
            if (!source.isPlaying) source.Play();

            activeObject = Instantiate(prefabs[11], Vector3.zero, Quaternion.identity);
            activeObject.transform.Rotate(90, 0, 0);
            //тут должно совпадать с координатами соответствующей мишени
            activeObject.transform.position = ImagePos.position;

            if (AnnounsementPanel != null) AnnounsementPanel.SetActive(false);
            prefabRegulation = false;
        }
    }
    public void ImageTarget13(Transform ImagePos) // бльшой усач
    {
        if (prefabRegulation)
        {
            Debug.Log("тринадцатая мишень найдена");
            starPanel[12].GetComponent<Image>().sprite = Resources.Load<Sprite>("UI/sunIconGreen");
            source.clip = clips[12];
            if (!source.isPlaying) source.Play();

            activeObject = Instantiate(prefabs[12], Vector3.zero, Quaternion.identity);
            activeObject.transform.Rotate(90, 0, 0);
            //тут должно совпадать с координатами соответствующей мишени
            activeObject.transform.position = ImagePos.position;

            if (AnnounsementPanel != null) AnnounsementPanel.SetActive(false);
            prefabRegulation = false;
        }
    }
    public void ImageTarget14(Transform ImagePos) // мох
    {
        if (prefabRegulation)
        {
            Debug.Log("четырнадцатая мишень найдена");
            starPanel[13].GetComponent<Image>().sprite = Resources.Load<Sprite>("UI/sunIconGreen");
            source.clip = clips[13];
            if (!source.isPlaying) source.Play();

            activeObject = Instantiate(prefabs[13], Vector3.zero, Quaternion.identity);
            activeObject.transform.Rotate(90, 0, 0);
            //тут должно совпадать с координатами соответствующей мишени
            activeObject.transform.position = ImagePos.position;

            if (AnnounsementPanel != null) AnnounsementPanel.SetActive(false);
            prefabRegulation = false;
        }
    }
    public void ImageTarget15(Transform ImagePos) // туя
    {
        if (prefabRegulation)
        {
            Debug.Log("пятнадцатая мишень найдена");
            starPanel[14].GetComponent<Image>().sprite = Resources.Load<Sprite>("UI/sunIconGreen");
            source.clip = clips[14];
            if (!source.isPlaying) source.Play();
            activeObject = Instantiate(prefabs[14], Vector3.zero, Quaternion.identity);
            activeObject.transform.Rotate(90, 0, 0);
            //тут должно совпадать с координатами соответствующей мишени
            activeObject.transform.position = ImagePos.position;

            if (AnnounsementPanel != null) AnnounsementPanel.SetActive(false);
            prefabRegulation = false;
        }
    }
    public void ExitTarget(AudioSource source)
    {
        if (activeObject != null)
        {
            Destroy(activeObject);           
            source.Pause();
            if (AnnounsementPanel != null) AnnounsementPanel.SetActive(true);
            prefabRegulation = true;
        }       
    }

    public void ChangeActivity()
    {
        activity = !activity;
        Debug.Log("activity " + activity);
    }

    void Update()
    {
        if (soundSlider!=null) source.volume = soundSlider.value;
    }
}