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
    
    
    
    //int clearStage = 0;

    //public void SetStarts(int completedStages)
    //{
    //    clearStage = completedStages;

    //    for(int i = 0; i < starts.Length; i++)
    //    {
    //        starts[i].gameObject.SetActive(i < clearStage);
    //    }
    //}
    
    
    private void Start()
    {
        stars[0].gameObject.SetActive(false);
        stars[1].gameObject.SetActive(false);
        stars[2].gameObject.SetActive(false);
    }
    private void Update()
    {
        
    }
    // �ؽ�Ʈ ��ư�� ������ �� Ŭ���� ���� Ȯ�� �� �� Ȱ��ȭ
    //public void OnNextButtonClicked()
    //{
    //    //// �ؽ�Ʈ ��ư�� ������ ���� 1�� ������ Ŭ���� ǥ�÷ν� ���� Ȱ��ȭ
    //    //if (/*SceneManager.GetActiveScene().buildIndex == 1*/)
    //    //{
    //    //    stars[0].gameObject.SetActive(true);

    //    //    LoadingSceneController.LoadScene(1);
    //    //}
    //    SceneManager.GetSceneByBuildIndex(1);
    //    LoadingSceneController.LoadScene(1);
    //    stars[0].gameObject.SetActive(true);


    //}
    //public void Onpointerup(PointerEventData eventData)
    //{
    //    SceneManager.GetSceneByBuildIndex(1);
    //    LoadingSceneController.LoadScene(1);
    //    stars[0] .gameObject.SetActive(true);
    //}
    

    
}
