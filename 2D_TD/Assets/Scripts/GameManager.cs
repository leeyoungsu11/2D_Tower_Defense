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

    //���� �� 3�ʵڿ� �����ϴ°Ŷ�
    //���ʹ� �� ������ Success()�Լ� �θ���
    //ü�� �������� ���� ���߱�
    /* TextContrl.instance.NextScene();*/

    public void Pause()
    {
        isPause = true;
        Time.timeScale = 0;
    }
}
