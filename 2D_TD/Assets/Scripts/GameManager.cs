using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Text Hp_T;
    public Text Wave_T;
    public Text Gold_T;
    private int Hp = 0;
    private int Wave = 0;
    private int Gold = 0;
    private int MaxWave = 0;
    // Start is called before the first frame update
    void Start()
    {
        MaxWave = 5;
        Gold = 500;
        Hp = 20;
    }


    void Start()
    {
        //enemies = GameObject.FindGameObjectsWithTag("Enemy"); // ���ʹ�����
    }

    
    void Update()
    {
        Hp_T.text = $"{Hp}";
        Wave_T.text = $"Wave : {Wave} / {MaxWave}";
        Gold_T.text = $"{Gold}";
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


    public int GetGold()
    {
        return Gold;
    }
    public void SetGold(int val)
    {
        this.Gold -= val;
    }
}
