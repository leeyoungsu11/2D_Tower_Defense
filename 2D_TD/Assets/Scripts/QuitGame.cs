using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitGame : MonoBehaviour
{
    void update()
    {
        if(Input.GetKeyUp(KeyCode.Escape))
        {
            GameExit();
        }
    }

    public void GameExit()
    {
        Application.Quit();
    }
}
