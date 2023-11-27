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

    // Update is called once per frame
    void Update()
    {
        Hp_T.text = $"{Hp}";
        Wave_T.text = $"Wave : {Wave} / {MaxWave}";
        Gold_T.text = $"{Gold}";
    }

    public void Hit()
    {
        Hp--;
    }

    public void WaveUp()
    {
        Wave++;
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
