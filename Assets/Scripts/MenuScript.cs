using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    public void OnPlayButton()
    {
        Cursor.visible = false;
        SceneManager.LoadScene(2);
    }

    public void OnOptionsButton()
    {
        SceneManager.LoadScene(1);
    }

    public void OnQuitButton()
    {
        Application.Quit();
    }

    public void OnBackButton()
    {
        Cursor.visible = true;
        SceneManager.LoadScene(0);
    }
}
