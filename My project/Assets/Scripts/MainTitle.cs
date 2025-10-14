using UnityEngine;
using UnityEngine.SceneManagement;
public class MainTitle : MonoBehaviour
{
  
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void exit()
    {
        Application.Quit();
    }
    public void startgame()
    {
        SceneManager.LoadScene("Master");
    }
}
