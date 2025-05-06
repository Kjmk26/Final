using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class Transicion : MonoBehaviour
{
    public static Transicion instance;
    private CanvasGroup panelFade;
    public float fadeDuration = 1.5f;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
            return;
        }
    }

    void Start()
    {
        FindPanelFade();
        StartCoroutine(FadeIn());  // Asegura que haya un fade-in cuando inicie la escena
    }

    public void LoadScene(string sceneName)
    {
        StartCoroutine(FadeToScene(sceneName));
    }

    private IEnumerator FadeToScene(string sceneName)
    {
        yield return StartCoroutine(FadeOut());  // Hace fade-out antes de cambiar de escena
        SceneManager.sceneLoaded += OnSceneLoaded;
        SceneManager.LoadScene(sceneName);
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
        FindPanelFade();
        StartCoroutine(FadeIn());  // Hace fade-in en la nueva escena
    }

    private void FindPanelFade()
    {
        GameObject panelObj = GameObject.Find("PanelFade");
        if (panelObj)
        {
            panelFade = panelObj.GetComponent<CanvasGroup>();
            panelFade.alpha = 1f; // Asegura que el PanelFade empieza en negro en la nueva escena
        }
        else
        {
            Debug.LogWarning("No se encontró el PanelFade en la nueva escena.");
        }
    }

    private IEnumerator FadeOut()
    {
        if (panelFade == null) yield break;

        panelFade.blocksRaycasts = true; // Bloquea botones durante el fade
        float timer = 0f;
        while (timer < fadeDuration)
        {
            timer += Time.deltaTime;
            panelFade.alpha = Mathf.Lerp(0f, 1f, timer / fadeDuration);
            yield return null;
        }
    }

    private IEnumerator FadeIn()
    {
        if (panelFade == null) yield break;

        float timer = 0f;
        while (timer < fadeDuration)
        {
            timer += Time.deltaTime;
            panelFade.alpha = Mathf.Lerp(1f, 0f, timer / fadeDuration);
            yield return null;
        }

        panelFade.blocksRaycasts = false; // Permite interactuar con los botones después del fade
    }
}