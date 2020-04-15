using UnityEngine;
using UnityEngine.SceneManagement;

public class Credits : MonoBehaviour
{

    public void Quit()
    {
        Debug.Log("quitting");
        Application.Quit();
    }

    public void StartGame()
    {
        SceneManager.LoadScene(0);
    }

}
