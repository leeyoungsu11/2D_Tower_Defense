using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Text Hp_T;
    public Text Wave_T;
    private int Hp = 20;
    private int Wave = 0;
    private int MaxWave = 5;
    bool isPause = false;
    //public GameObject successText; 
    //private GameObject[] enemies; // 적을 추적하기 위한 배열
    
    private void Awake()
    {
        Time.timeScale = 1;
    }


    void Start()
    {
        //enemies = GameObject.FindGameObjectsWithTag("Enemy"); // 에너미저장
    }

    
    void Update()
    {
        Hp_T.text = $"{Hp}";
        Wave_T.text = $"Wave : {Wave} / {MaxWave}";
        //if (AreAllEnemiesDead())
        //{
        //    ShowSuccessText();
        //} // 죽었는지 확인후 죽으면 텍스트
    }

    public void Hit()
    {
        Hp--;
        if(Hp <= 0)
        {
            TextContrl.instance.ShowGameOver();
            TextContrl.instance.ReTryBtn();
            TextContrl.instance.NextBtn();
            Pause();
            
        }
    }

    public void WaveUp()
    {
        Wave++;
        
    }

    //게임 한 3초뒤에 시작하는거랑
    //에너미 다 죽으면 Success()함수 부르기
    //스테이지마다 동일한지 보기
    //꾸밀거 있으면 더 꾸미기 
    //팁 패널 킬때 모두 끄기 << 시도
   

    public void Pause()
    {
        isPause = true;
        Time.timeScale = 0;
    }


}
