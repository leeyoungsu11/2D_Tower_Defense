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

  
 
    private void Awake()
    {
        if (TextContrl.instance == null)
        {
            TextContrl.instance = this;
        }
    }

    private void Start()
    {
            readyText.SetActive(false);

        
            gameOverText.SetActive(false);

        
            SuccessText.SetActive(false);

        
            NextButton.gameObject.SetActive(false);

        
            ReTryButton.gameObject.SetActive(false);

        
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
    
   
}
