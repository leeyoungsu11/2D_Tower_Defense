using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadingSceneController : MonoBehaviour
{
    //public static string nextScene;
    public static int nextScene;

    Scene thisscene;
    [SerializeField]
    Image progressBar;
    //public static void LoadScene(string sceneName)
    //{
    //    nextScene = sceneName;
    //    SceneManager.LoadScene("LoadingScene");
    //}
    public static void LoadScene(int sceneName)
    {        
        nextScene = sceneName;        
        SceneManager.LoadScene("LoadingScene");
    }

    private void Start()
    {        
        StartCoroutine(LoadSceneProcess());
    }

    IEnumerator LoadSceneProcess()
    {        
        AsyncOperation op = SceneManager.LoadSceneAsync(nextScene);
        op.allowSceneActivation = false;

        float timer = 0f;
        while(!op.isDone)
        {
            yield return null;

            if (op.progress < 0.9f)
            {
                progressBar.fillAmount = op.progress;
            }
            else
            {
                timer += Time.unscaledDeltaTime;
                progressBar.fillAmount = Mathf.Lerp(0.1f, 1f, timer);
                if(progressBar.fillAmount >= 1f)
                {
                    op.allowSceneActivation = true;
                    yield break; 
                }
            }
        }
        
        //SceneManager.UnloadSceneAsync("LoadingScene");

        thisscene = SceneManager.GetSceneByName("LoadingScene");
        SceneManager.UnloadSceneAsync(thisscene,UnloadSceneOptions.None);
    }
}
