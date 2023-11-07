using UnityEngine;
using UnityEngine.Events;

public class TimeManager : MonoBehaviour
{
    public UnityEvent GPaused;

    public UnityEvent GResumed;

    private bool Paused;

    public GameObject PauseScreen;

    // Start is called before the first frame update
    void Start()
    {
        PauseScreen.SetActive(false);
        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Paused = !Paused;


            if (Paused)
            {
                Time.timeScale = 0;
                PauseScreen.SetActive(true);
            }
            else
            {
                Time.timeScale = 1;
                PauseScreen.SetActive(false);
            }
        }
    }
}
