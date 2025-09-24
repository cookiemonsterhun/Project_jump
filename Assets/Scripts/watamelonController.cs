using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class watamelonController : MonoBehaviour
{

    public void NextLevel()
    {
        SceneManager.LoadScene("Level_02");
    }
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            NextLevel();
        }
    }
}
