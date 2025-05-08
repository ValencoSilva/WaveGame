using UnityEngine;
using UnityEngine.SceneManagement;

public class buttons : MonoBehaviour
    
{
    [SerializeField] string levelName;
    
    
    
    public void Resume()
    {
        gameManager.instance.isNotPaused();
    }
    
    public void Restart()
    {
        
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        gameManager.instance.isNotPaused();
    }

    public void Quit()
    {
        SceneManager.LoadScene(levelName);
    }
}
