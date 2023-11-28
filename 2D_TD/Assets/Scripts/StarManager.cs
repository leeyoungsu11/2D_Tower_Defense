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
    // �������� Ŭ���� ���¸� �����ϴ� �Լ�
    public void SetStageCleared(int stageNumber)
    {
        // �������� Ŭ���� ���¸� ����
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
    // �ؽ�Ʈ ��ư�� ������ �� Ŭ���� ���� Ȯ�� �� �� Ȱ��ȭ
    public void OnNextButtonClicked()
    {
        // �ؽ�Ʈ ��ư�� ������ ���� 1�� ������ Ŭ���� ǥ�÷ν� ���� Ȱ��ȭ
        if (SceneManager.GetActiveScene().buildIndex == 1)
        {
                stars[0].gameObject.SetActive(true);
                Debug.Log("1�� �������� Ŭ����!");
        }

        
    }
}
