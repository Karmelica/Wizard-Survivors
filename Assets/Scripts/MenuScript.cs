using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    [SerializeField] public Animator animatorTerrain;
    [SerializeField] public Animator animatorCanvas;
    [SerializeField] public GameObject canvas;

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
}
