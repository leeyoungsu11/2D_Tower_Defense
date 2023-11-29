using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public Text Hp_T;
    public Text Wave_T;
    public Text Gold_T;
   
    private int Hp = 0;
    private int Wave = 0;
    private int Gold = 0;
    private int MaxWave = 0;
    public GameObject[] Obj;
   
    private bool isend = false;

   
    void Start()
    {
        Scene scene = SceneManager.GetActiveScene();
        MaxWave = 5;
        Gold = 500;
        if (scene.buildIndex != 4)
        {
            Hp = 20;
        }
        else if (scene.buildIndex == 4)
        {
            Hp = 1;
        }
        
        //score = 0;
         //enemyscript = gameObject.GetComponent<Enemy>();
        
}

    void Update()
    {
        Scene scene = SceneManager.GetActiveScene();

        if (scene.buildIndex != 4)
        {
            Wave_T.text = $"Wave : {Wave} / {MaxWave}";
        }
        else if(scene.buildIndex == 4)
        {
            Wave_T.text = "Boss";
        }
        Hp_T.text = $"{Hp}";
        Gold_T.text = $"{Gold}";
        

        Obj = GameObject.FindGameObjectsWithTag("Enemy");
        if (Obj.Length <= 0 && Hp != 0 && isend == true)
        {
            TextContrl.instance.showSuccess();
            TextContrl.instance.NextBtn();
            TextContrl.instance.BackBtn();
            Pause();
        }
    }
   
    public void Hit()
    {
        Hp--;
        if(Hp <= 0)
        {
            TextContrl.instance.ShowGameOver();
            TextContrl.instance.ReTryBtn();
            TextContrl.instance.NextBtn();
            TextContrl.instance.BackBtn();
            Pause();
            
            
        }
        
    }

    
    public void WaveUp()
    {
        Wave++;
        
    }

   
   

    public void Pause()
    {
        Time.timeScale = 0;
    }

    public void Resume()
    {
        Time.timeScale = 1;
    }

    public int GetGold()
    {
        return Gold;
    }
    public void SetGold(int val)
    {
        this.Gold -= val;
    }
    public void UpGold(int val)
    {
        this.Gold += val;
    }
    public void end()
    {
        isend = true;
    }

    
}
