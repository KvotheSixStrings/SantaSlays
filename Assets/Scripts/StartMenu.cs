using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class StartMenu : MonoBehaviour
{
    
    
    public void StartLevel()

    {
        SceneManager.LoadScene("MainLevel");

    }

    public void Yes()

    {
        Application.Quit();

    }

}
