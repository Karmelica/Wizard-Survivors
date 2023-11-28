using UnityEngine;
using UnityEngine.Events;

public class TimeManager : MonoBehaviour
{
    public UnityEvent GPaused;
    public UnityEvent GResumed;
    public bool Paused;
    
    [Header("Screens")]
    public GameObject PauseScreen;
    public GameObject GameOverScreen;
    
    [Header("Components")]
    public ShopManager shopManager;
    

    // Start is called before the first frame update
    void Start()
    {
        GameOverScreen.SetActive(false);
        PauseScreen.SetActive(false);
        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && shopManager.check == false)
        {
            Paused = !Paused;


            if (Paused)
            {
                Cursor.visible = true;
                Time.timeScale = 0;
                PauseScreen.SetActive(true);
            }
            else
            {
                Cursor.visible = false;
                Time.timeScale = 1;
                PauseScreen.SetActive(false);
            }
        }

        if (Stats.currentHp <= 0)
        {
            Time.timeScale = 0;
            GameOverScreen.SetActive(true);
        }
    }
}
