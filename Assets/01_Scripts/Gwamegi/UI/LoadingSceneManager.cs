using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadingSceneManager : MonoBehaviour
{
    public static string nextScene;
    /// <summary>
    /// 로딩 정도를 나타내는 Bar
    /// </summary>
    [SerializeField] GameObject progressBar;

    private void Start()
    {
        StartCoroutine(LoadScene());
    }

    public static void LoadScene(string sceneName)
    {
        nextScene = sceneName;
        SceneManager.LoadScene("LoadingScene");
    }

    IEnumerator LoadScene()
    {
        yield return null;
        AsyncOperation op = SceneManager.LoadSceneAsync(nextScene);
        op.allowSceneActivation = false;
        float timer = 0.0f;
        while (!op.isDone)
        {
            yield return null;
            timer += Time.deltaTime;
            if (op.progress < 0.9f)
            {
                progressBar.transform.localScale = new Vector3(Mathf.Lerp(progressBar.transform.localScale.x, op.progress, timer), 1, 1);
                if (progressBar.transform.localScale.x >= op.progress)
                {
                    timer = 0f;
                }
            }
            else
            {
                progressBar.transform.localScale = new Vector3(Mathf.Lerp(progressBar.transform.localScale.x, 1f, timer), 1, 1);
                if (progressBar.transform.localScale.x == 1.0f)
                {
                    op.allowSceneActivation = true;
                    yield break;
                }
            }
        }
    }
}
