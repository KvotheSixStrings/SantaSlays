using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class StartMenu : MonoBehaviour
{
    public Canvas quitMenu;
    public Button playText;
    public Button exitText;
    public Canvas conrolMenu;
    public Button controlsText;
    public Button creditText;
    public Canvas creditMenu;




    void Start()

    {
        quitMenu.gameObject.SetActive(false); 
        conrolMenu.gameObject.SetActive(false);
        creditMenu.gameObject.SetActive(false);

    }

    public void ExitPress()

    {
        quitMenu.gameObject.SetActive(true);
        playText.gameObject.SetActive(false);     
        exitText.gameObject.SetActive(false);
        controlsText.gameObject.SetActive(false);
        creditText.gameObject.SetActive(false);
        

    }

    public void ConrolsPress()
    {
        conrolMenu.gameObject.SetActive(true); 
        playText.gameObject.SetActive(false); 
        exitText.gameObject.SetActive(false); 
        controlsText.gameObject.SetActive(false);
        creditText.gameObject.SetActive(false);
    }

    public void CreditPress()
    {
        creditMenu.gameObject.SetActive(true);
        playText.gameObject.SetActive(false);
        exitText.gameObject.SetActive(false);
        controlsText.gameObject.SetActive(false);
        creditText.gameObject.SetActive(false);
    }

    public void No()

    {
        conrolMenu.gameObject.SetActive(false); 
        quitMenu.gameObject.SetActive(false);
        creditMenu.gameObject.SetActive(false);
        playText.gameObject.SetActive(true);
        exitText.gameObject.SetActive(true); 
        controlsText.gameObject.SetActive(true);
        creditText.gameObject.SetActive(true);

    }
    
    public void StartLevel()

    {
        SceneManager.LoadScene(1);

    }

    public void Yes()

    {
        Application.Quit();

    }

}
