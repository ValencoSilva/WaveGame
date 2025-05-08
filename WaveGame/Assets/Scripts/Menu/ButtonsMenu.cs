using UnityEngine;
using UnityEngine.SceneManagement;
public class ButtonsMenu : MonoBehaviour
{
    [SerializeField] string nameLevel;
    [SerializeField] GameObject menu;
    [SerializeField] GameObject setting;

     public void Play()
    {
        SceneManager.LoadScene(nameLevel);
        gameManager.instance.isNotPaused();
    }

    public void Setting()
    {
        menu.SetActive(false);
        setting.SetActive(true);
    }


    public void Menu()
    {
        menu.SetActive(true);
        setting.SetActive(false);
    }

    public void Quit()
    {
#if UNITY_EDITOR
        //UnityEditor.EditorApplication.isPlaying = false;
        Application.Quit();

#else
#endif
    }
}
