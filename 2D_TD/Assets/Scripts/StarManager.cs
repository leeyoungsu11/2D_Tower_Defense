using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StarManager : MonoBehaviour
{
    public Image[] stars = new Image[0];
    

    //int clearStage = 0;

    //public void SetStarts(int completedStages)
    //{
    //    clearStage = completedStages;

    //    for(int i = 0; i < starts.Length; i++)
    //    {
    //        starts[i].gameObject.SetActive(i < clearStage);
    //    }
    //}
    // 스테이지 클리어 상태를 저장하는 함수
    public void SetStageCleared(int stageNumber)
    {
        // 스테이지 클리어 상태를 저장
        PlayerPrefs.SetInt("Stage_" + stageNumber + "_cleared", 1);
    }
    private void Start()
    {
        if (stars == null)
        {  }
        stars[0].gameObject.SetActive(false);
        stars[1].gameObject.SetActive(false);
        stars[2].gameObject.SetActive(false);
    }
    private void Update()
    {
        
    }
    // 넥스트 버튼을 눌렀을 때 클리어 상태 확인 및 별 활성화
    public void OnNextButtonClicked()
    {
        // 넥스트 버튼을 눌렀을 때만 1번 씬에서 클리어 표시로써 별을 활성화
        if (SceneManager.GetActiveScene().buildIndex == 1)
        {
                stars[0].gameObject.SetActive(true);
                Debug.Log("1번 스테이지 클리어!");
        }

        
    }
}
