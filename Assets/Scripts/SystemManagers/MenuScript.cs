using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    public Animator animatorTerrain;
    public Animator animatorCanvas;
    public GameObject canvas;

    private IEnumerator Licznik()
    {
        animatorCanvas.SetBool("Start", true);
        yield return new WaitForSeconds(1);
        animatorTerrain.SetBool("Start", true);
        yield return new WaitForSeconds(2.3f);
        SceneManager.LoadScene(2);
    }
    public void OnPlayButton()
    {
        Cursor.visible = false;
        StartCoroutine(Licznik());
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

    private void Start()
    {
        Time.timeScale = 1;
        if (PlayerPrefs.HasKey("musicVolume"))
        {
            AudioListener.volume = PlayerPrefs.GetFloat("musicVolume");
        }
    }
}
