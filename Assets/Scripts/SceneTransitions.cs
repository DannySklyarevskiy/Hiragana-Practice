using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransitions : MonoBehaviour
{
    public GameObject sceneManager;
    public GameObject panelCanvas;
    public GameObject scoreStorage;
    public Animator anim;

    void Awake()
    {
        //Scene mangager singleton
        DontDestroyOnLoad(sceneManager);
        int sceneManagerCount = FindObjectsOfType<SceneTransitions>().Length;
        if (sceneManagerCount > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }

        //Panel canvas singleton
        DontDestroyOnLoad(panelCanvas);
        int panelCanvasCount = GameObject.FindGameObjectsWithTag("Panel canvas").Length;
        if (panelCanvasCount > 1)
        {
            Destroy(panelCanvas);
        }
        else
        {
            DontDestroyOnLoad(panelCanvas);
        }

        //Score singleton
        DontDestroyOnLoad(scoreStorage);
        int scoreCount = GameObject.FindGameObjectsWithTag("Score").Length;
        if (scoreCount > 1)
        {
            Destroy(scoreStorage);
        }
        else 
        {
            DontDestroyOnLoad(scoreStorage);
        }
    }

    private void Start()
    {
        StartCoroutine(LoadStartSceneFirstTime());
    }

    public void LoadStartSceneFunction()
    {
        StartCoroutine(LoadStartScene());
    }

    public void LoadMistakesSceneFunction()
    {
        StartCoroutine(LoadMistakesScene());
    }

    public void LoadGameSceneFunction()
    {
        StartCoroutine(LoadGameScene());
    }

    public void LoadGameOverSceneFunction()
    {
        StartCoroutine(LoadGameOverScene());
    }

    public IEnumerator LoadStartScene()
    {
        panelCanvas.SetActive(true);
        anim.Play("end");
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene("Start");
        anim.Play("start");
        yield return new WaitForSeconds(1f);
        panelCanvas.SetActive(false);
    }

    public IEnumerator LoadMistakesScene()
    {
        panelCanvas.SetActive(true);
        anim.Play("end");
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene("Mistakes");
        anim.Play("start");
        yield return new WaitForSeconds(1f);
        panelCanvas.SetActive(false);
    }

    public IEnumerator LoadGameScene()
    {
        panelCanvas.SetActive(true);
        anim.Play("end");
        yield return new WaitForSeconds(1f);

        FindObjectOfType<Score>().ResetScore();

        FindObjectOfType<Mistakes>().letterMistakes.Clear();
        FindObjectOfType<Mistakes>().translationMistakes.Clear();

        SceneManager.LoadScene("Game");
        anim.Play("start");
        yield return new WaitForSeconds(1f);
        panelCanvas.SetActive(false);
    }

    public IEnumerator LoadGameOverScene()
    {
        panelCanvas.SetActive(true);
        anim.Play("end");
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene("Game over");
        anim.Play("start");
        yield return new WaitForSeconds(1f);
        panelCanvas.SetActive(false);
    }

    public IEnumerator LoadStartSceneFirstTime()
    {
        panelCanvas.SetActive(true);
        anim.Play("start");
        yield return new WaitForSeconds(1f);
        panelCanvas.SetActive(false);

        HighScoreData data = SaveSystem.LoadHighScore();
        FindObjectOfType<Score>().highScore = data.highScore;
    }
}
