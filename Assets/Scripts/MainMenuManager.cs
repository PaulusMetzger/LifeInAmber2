using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuManager : MonoBehaviour
{
    public Slider m_Slider;

    public static float volumeLevel;
    void Update()
    {
        volumeLevel = m_Slider.value;
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

    public void ReturnMenu()
    {
        SceneManager.LoadScene(0, LoadSceneMode.Single);
    }
}
