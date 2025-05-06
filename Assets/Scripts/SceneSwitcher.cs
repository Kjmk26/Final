using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
    public string sceneName;
    private SceneSwitcher Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    public void SwitchScene()
    {
        SceneManager.LoadScene(sceneName);
    }

    public void OnPlayButtonPressed()
    {
        Transicion.instance.LoadScene(sceneName);
    }

    public void Salir()
    {
        Application.Quit();
    }

    public void SwitchSceneMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
