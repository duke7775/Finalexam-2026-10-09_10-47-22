
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    public void MadDriver()
    {
        SceneManager.LoadScene("Prototype 1");
    }

    public void FlyLikeABird()
    {
        SceneManager.LoadScene("Challenge 1");
    }

    public void Sumo()
    {
        SceneManager.LoadScene("Challenge 4");
    }

    public void ExitGame()
    {
        Application.Quit();
        Debug.Log("Exit Game");
    }
}
