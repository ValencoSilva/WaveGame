using UnityEngine;
using UnityEngine.UI;

public class gameManager : MonoBehaviour
{
    public static gameManager instance;

    public Image healthBar;
    [SerializeField] GameObject pause;
    [SerializeField] GameObject gameOver;


    public GameObject player;
    public Transform playerTransform;

    public bool IsPaused;

    public float timeScaleOrig;
     void Awake()
    {
        Time.timeScale = 1f;
        instance = this;
        player = GameObject.FindGameObjectWithTag("Player");
        playerTransform = player.transform;
        timeScaleOrig = Time.timeScale;
        
    }
 
    void Update()
    {
        if (Input.GetButtonDown("Cancel"))
        {
            
            if(!IsPaused)
            {
                isPaused();
                pause.SetActive(true);

            }
           else if (IsPaused)
            {
                isNotPaused();
            }

        }
    }

    public void isPaused() {
    IsPaused = true;
    Time.timeScale = 0;
    Cursor.lockState = CursorLockMode.None;
    Cursor.visible = true;
       
    }

    public void isNotPaused()
    {
        IsPaused = !IsPaused;
        Time.timeScale = timeScaleOrig;
        Cursor.lockState = CursorLockMode.Locked;
        pause.SetActive(false);
        gameOver.SetActive(false);
        Cursor.visible = false;
       

    }

    public void GameOver()
    {
        isPaused();
        gameOver.SetActive(true);
    }
}
