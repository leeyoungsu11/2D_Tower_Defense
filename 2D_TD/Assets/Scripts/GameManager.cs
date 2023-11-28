using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public Text Hp_T;
    public Text Wave_T;
    public Text Gold_T;
   // public Text score_T;
    private int Hp = 0;
    private int Wave = 0;
    private int Gold = 0;
    private int MaxWave = 0;
    public GameObject[] Obj;
    //private int score = 0;
    //Enemy enemyscript;
    private bool isend = false;

    // Start is called before the first frame update
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
        //score_T.text = $"{score}";

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
            Pause();
            
        }
        
    }

    //public void Scoreup()
    //{
    //    score++;
        
    //    if(score >= 20)
    //    {
    //        TextContrl.instance.showSuccess();
    //    }
    //}

    public void WaveUp()
    {
        Wave++;
        
    }

   
   

    public void Pause()
    {
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

    public void end()
    {
        isend = true;
    }

    
}
