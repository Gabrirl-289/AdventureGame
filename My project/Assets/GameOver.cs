using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public void exit()
    {
        SceneManager.LoadScene("Title");
    }
    public void startgame()
    {
        SceneManager.LoadScene("Master");
    }
}
