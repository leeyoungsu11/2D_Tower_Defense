using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    private static LevelManager instance = null;
    public static LevelManager Instance => instance;

    [SerializeField]
    public int Level { get; private set; } = 0;


    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            if (instance != this)
            {
                Destroy(this);
            }
        }
    }


    public void Clear(int stage)
    {
        int val = stage - 1;
        if (val > Level)
        {
            Level = val;
        }
    }
}
