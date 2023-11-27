using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextContrl : MonoBehaviour
{
    public static TextContrl instance;

    public GameObject readyText;

    public GameObject gameOverText;

    public GameObject SuccessText;

    public Button NextButton;

    public Button ReTryButton;

    public Text AAAText;

    public GameObject instructionsPanel;
 
    private void Awake()
    {
        if(TextContrl.instance == null)
        {
            TextContrl.instance = this;
        }
    }

    private void Start()
    {
        instructionsPanel.SetActive(false);

        if(readyText!=null)
        readyText.SetActive(false);

        if (gameOverText != null)
            gameOverText.SetActive(false);

        if (SuccessText != null)
            SuccessText.SetActive(false);

        if (NextButton != null)
            NextButton.gameObject.SetActive(false);

        if (ReTryButton != null)
            ReTryButton.gameObject.SetActive(false);

        if (readyText != null)
            StartCoroutine(ShowReady());
    }

    IEnumerator ShowReady()
    {        
            int count = 0;
        while(count < 3)
        {            
            readyText.SetActive(true);
            yield return new WaitForSeconds(0.5f);

            readyText.SetActive(false);

            yield return new WaitForSeconds(0.5f);
            count++;
        }

    }

    public void ShowGameOver()
    {
        gameOverText.SetActive(true);
    }


    public void showSuccess()
    {
        SuccessText.SetActive(true);
    }

    public void NextBtn()
    {
        NextButton.gameObject.SetActive(true);
    }
    
    public void ReTryBtn()
    {
        ReTryButton.gameObject.SetActive(true);
    }
    
    public void ShowPanel()
    {
        instructionsPanel.SetActive(true);

        AAAText.text = "1. ���� �ϴ��� Ÿ���� Ŭ���� �ʵ忡 Ÿ���� ��ġ�ϼ���.\n" +
            "2.������ �������� ��ġ�� �� �ֽ��ϴ�." +
            "\n3. ���� óġ�ؼ� ��带 ��� Ÿ���� ���׷��̵� �ϼ���.\n4. HP�� 0�̵Ǹ� ������ �����ϴ�.   ";
    }

    public void HidePanel()
    {
        instructionsPanel.SetActive(false);
    }
}
