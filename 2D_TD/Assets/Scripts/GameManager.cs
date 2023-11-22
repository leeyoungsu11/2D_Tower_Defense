using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Text Hp_T;
    public Text Wave_T;
    private int Hp = 20;
    private int Wave = 1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Hp_T.text = $"Hp : {Hp}";
        Wave_T.text = $"Wave : {Wave}";
    }

    public void Hit()
    {
        Hp--;
    }

    public void WaveUp()
    {
        Wave++;
    }
}
