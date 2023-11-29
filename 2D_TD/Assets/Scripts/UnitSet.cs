using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitSet : MonoBehaviour
{
    SpriteRenderer sprite;
    private float Delay = 0;
    public float ShotSpeed { get; private set; }
    public float ShotRange { get; private set; }
   
    //SpriteRenderer sprite;
    // Start is called before the first frame update
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
    }
    public void SetUp()
    {
        ShotSpeed = 1.0f;
        ShotRange = 3;
    }
    // Update is called once per frame
    void Update()
    {
        Delay += Time.deltaTime;
        if(Delay < 1.0f)
        {
            gameObject.transform.localScale = Vector3.zero;
        }
        else if(Delay >= 1.0f)
        {
            gameObject.transform.localScale = Vector3.one;
        }
    }
    public void Upgrade()
    {
        sprite.color = Color.red;
        ShotSpeed = 0.5f;
        ShotRange = 4;
    }

}
