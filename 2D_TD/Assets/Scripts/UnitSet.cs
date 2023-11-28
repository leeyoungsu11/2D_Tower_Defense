using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitSet : MonoBehaviour
{
    SpriteRenderer sprite;
    private float Delay = 0;
    //SpriteRenderer sprite;
    // Start is called before the first frame update
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        //gameObject.SetActive(false);
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
        Debug.Log("up");
        sprite.color = Color.red;
    }

}
