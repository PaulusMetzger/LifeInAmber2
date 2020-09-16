using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuSc : MonoBehaviour
{
    
    public GameObject InfoPanel;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }
    public void StartGame()
    {
        SceneManager.LoadScene(1, LoadSceneMode.Single);
    }
  
    public void info()
    {
        InfoPanel.SetActive(!InfoPanel.activeSelf);
    }
    public void CloseInfo()
    {
        InfoPanel.SetActive(false);
    }
    
    public void ExitApp()
    {
        Application.Quit();
    }
}