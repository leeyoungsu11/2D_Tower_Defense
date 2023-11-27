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
        
        AAAText.text = "1. ���� �ϴ��� Ÿ���� Ŭ���� �ʵ忡 Ÿ���� ��ġ�ϼ���.\n2.������ �������� ��ġ�� �� �ֽ��ϴ�.\n3. ���� óġ�ؼ� ��带 ��� Ÿ���� ���׷��̵� �ϼ���.\n4. HP�� 0�̵Ǹ� ������ �����ϴ�.";


    }

    public void HidePanel()
    {
        instructionsPanel.SetActive(false);
        
    }
}
