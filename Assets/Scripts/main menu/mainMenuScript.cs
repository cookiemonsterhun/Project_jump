using UnityEngine;
using UnityEngine.SceneManagement;

public class mainMenuScript : MonoBehaviour
{
    public void Play()
    {
        SceneManager.LoadScene("Level_01");

    }

    public void Exit()
    {
        Application.Quit();
    }

    public void Help()
    {
        SceneManager.LoadScene("HelpMenu");
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("startScene");
    }
    
}
