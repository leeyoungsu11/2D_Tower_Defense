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
    // Start is called before the first frame update
    private void Awake()
    {
        Time.timeScale = 1;
    }


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Hp_T.text = $"{Hp}";
        Wave_T.text = $"Wave : {Wave} / {MaxWave}";
    }

    public void Hit()
    {
        Hp--;
        if(Hp <= 0)
        {
            TextContrl.instance.ShowGameOver();
            TextContrl.instance.ReTryBtn();
            Pause();
            //changeScene.Stop();
        }
    }

    public void WaveUp()
    {
        Wave++;
        
    }

    //게임 한 3초뒤에 시작하는거랑
    //에너미 다 죽으면 Success()함수 부르기
    //체력 없어지면 게임 멈추기
    /* TextContrl.instance.NextScene();*/

    public void Pause()
    {
        isPause = true;
        Time.timeScale = 0;
    }
}
