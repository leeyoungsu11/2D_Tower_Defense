using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Unity.VisualScripting;
using UnityEngine;

public class QuitGame : MonoBehaviour
{
    //    void Update()
    //    {
    //        if(Input.GetKeyDown(KeyCode.Escape))
    //        {
    //            GameExit();
    //        }
    //    }

    //    public void GameExit()
    //    {
    //#if UNITY_EDITOR
    //        UnityEditor.EditorApplication.isPlaying = false;
    //#else 

    //        Application.Quit();
    //    }
    public void ExitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit(); // ���ø����̼� ����
#endif
    }
    
}
