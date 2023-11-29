using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class StarManager : MonoBehaviour
{
    
    public Image[] stars;
    public Button[] StageButtons;
    public LevelManager levelManager;




    private void Start()
    {
        for (int i = 0; i < stars.Length; i++)
        {
            if (LevelManager.Instance.Level > i)
            {
                stars[i].gameObject.SetActive(true);
            }
            else
            {
                stars[i].gameObject.SetActive(false);
            }
        }
        for (int i = 0; i < StageButtons.Length; i++)
        {
            if (LevelManager.Instance.Level >= i)
            {
                StageButtons[i].interactable = true;
            }
            else
            {
                StageButtons[i].interactable = false;
            }
        }


    }
}
