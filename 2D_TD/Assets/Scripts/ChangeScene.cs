using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ChangeScene : MonoBehaviour
{
    //public string thisScene;

    private void Start()
    {        
    }
    public void GoChooseStage()
    {
        //SceneManager.LoadScene(1);        
        LoadingSceneController.LoadScene(1);
    }
    public void GoStage1_1()
    {
        //SceneManager.LoadScene(2);
        Time.timeScale = 1;
        LoadingSceneController.LoadScene(2);
    }
    public void Gostage1_2()
    {
        //SceneManager.LoadScene(3);
        Time.timeScale = 1;
        LoadingSceneController.LoadScene(3);
    }
    public void Gostage1_3()
    {
        Time.timeScale = 1;
        LoadingSceneController.LoadScene(4);
    }
    public void BackMainScene()
    {
        //SceneManager.LoadScene(0);
        LoadingSceneController.LoadScene(0);
    }

    //public void Stop()
    //{
    //    thisScene = SceneManager.GetActiveScene().name;
    //    Time.timeScale = 0f;
        
    //}
}
