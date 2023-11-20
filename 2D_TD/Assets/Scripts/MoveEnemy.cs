using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveEnemy : MonoBehaviour
{
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
        moveDir = dir;
    }
}