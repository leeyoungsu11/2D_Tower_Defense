using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Windows;

public class ChangeScene : MonoBehaviour
{
   public void GoChooseStage()
    {
        SceneManager.LoadScene(1);
        Debug.Log("버튼 클릭");
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
    private void Update()
    {
        
    }
}
