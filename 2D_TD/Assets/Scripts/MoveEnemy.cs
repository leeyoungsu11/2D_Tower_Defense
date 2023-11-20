using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveEnemy : MonoBehaviour
{
    Animator animator;

    [SerializeField]
    private float moveSpeed=0.0f;
    [SerializeField]
    private Vector3 moveDir = Vector3.zero;

    public float MoveSpeed => moveSpeed;
    void Update()
    {
        transform.position += moveDir * moveSpeed * Time.deltaTime;
        
    }
    public void moveTo(Vector3 dir)
    {
        Debug.Log(dir);
        moveDir = dir;
        if(dir.y < 0)
        {
            //animator.SetTrigger("D");
        }
        if(dir.x > 0)
        {
            animator.SetTrigger("R");
            
        }
        else if(dir.y > 0 )
        {
            animator.SetTrigger("U");
        }
    }

    void Start() 
    {
        animator = transform.GetComponent<Animator>();
    }
}
