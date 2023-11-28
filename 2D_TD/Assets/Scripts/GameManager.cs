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
    //private GameObject[] enemies; // ���� �����ϱ� ���� �迭
    
    private void Awake()
    {
        Time.timeScale = 1;
    }


    void Start()
    {
        //enemies = GameObject.FindGameObjectsWithTag("Enemy"); // ���ʹ�����
    }

    
    void Update()
    {
        Hp_T.text = $"{Hp}";
        Wave_T.text = $"Wave : {Wave} / {MaxWave}";
        //if (AreAllEnemiesDead())
        //{
        //    ShowSuccessText();
        //} // �׾����� Ȯ���� ������ �ؽ�Ʈ
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

    //���� �� 3�ʵڿ� �����ϴ°Ŷ�
    //���ʹ� �� ������ Success()�Լ� �θ���
    //������������ �������� ����
    //�ٹа� ������ �� �ٹ̱� 
    //�� �г� ų�� ��� ���� << �õ�
   

    public void Pause()
    {
        isPause = true;
        Time.timeScale = 0;
    }


}
