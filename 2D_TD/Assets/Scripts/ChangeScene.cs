using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ChangeScene : MonoBehaviour
{
    public GameObject loadingScreen;
   public void GoChooseStage()
    {
        
       SceneManager.LoadScene(1);
    }
    public void GoStage1_1()
    {
        SceneManager.LoadScene(2);
    }
    public void Gostage1_2()
    {
        SceneManager.LoadScene(3);
    }
    public void Gostage1_3()
    {
        SceneManager.LoadScene(4);
    }
    public void BackMainScene()
    {
        SceneManager.LoadScene(0);
    }

    
}
