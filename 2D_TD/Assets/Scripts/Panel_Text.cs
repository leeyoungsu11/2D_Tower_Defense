using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Panel_Text : MonoBehaviour
{
    //public static Panel_Text instance;

    public Text AAAText;
    
    public GameObject instructionsPanel;
    
    public Button DeleteButton;

    
    private void Update()
    {
        //if (Panel_Text.instance != null)
        //{
        //    Panel_Text.instance = this;
        //}
        
    }
    private void Start()
    {
        instructionsPanel.SetActive(false);
        
    }

    public void ShowPanel()
    {
        instructionsPanel.SetActive(true);

        AAAText.text = "1. 정해진 위치에 클릭하여 타워를 설치하세요.\n2. 설치된 타워를 클릭하면 업그레이드를 합니다.\n3. HP가 0이되면 게임이 끝납니다.\n4. 모든 적을 처치하세요!"; 


    }
    public void onlyshowpanel()
    {
        instructionsPanel.SetActive(true);
    }

    public void HidePanel()
    {
        instructionsPanel.SetActive(false);
        
    }
}
