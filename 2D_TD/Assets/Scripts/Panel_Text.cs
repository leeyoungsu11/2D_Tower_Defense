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
        
        AAAText.text = "1. 우측 하단의 타워를 클릭해 필드에 타워를 설치하세요.\n2.정해진 구역에만 설치할 수 있습니다.\n3. 적을 처치해서 골드를 얻고 타워를 업그레이드 하세요.\n4. HP가 0이되면 게임이 끝납니다.";


    }

    public void HidePanel()
    {
        instructionsPanel.SetActive(false);
        
    }
}
