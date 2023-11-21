using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveEnemy : MonoBehaviour
{
    /*
    움직임 스크립트 
    속도를 설정
    들어온 방향만큼 업데이트에서 포지션 바꿔줌
    */

    [SerializeField]
    private float moveSpeed=0.0f;
    [SerializeField]
    private Vector3 moveDir = Vector3.zero;

    public float MoveSpeed => moveSpeed;
    void Start() 
    {
        //animator = GetComponent<Animator>();
    }
    void Update()
    {
        transform.position += moveDir * moveSpeed * Time.deltaTime;
        
    }
    public void moveTo(Vector3 dir)
    {
        moveDir = dir;
    }

    
}
