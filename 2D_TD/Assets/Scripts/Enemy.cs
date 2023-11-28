using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    private int wayPointCount;
    private Transform[] wayPoints;
    private int currentIndex = 0;
    private MoveEnemy moveEnemy;
    GameObject gameManager;
    Animator animator;

    
    /*
    셋업 함수
    스포너에서 enemy프리팹 생성후 이함수를 호출
    매개변수로 transform배열을 받는다
    이는 만들어놓은 wayPoints의 배열을 뜻한다.
    enemy의 wayPoints에 들어온 wayPoints를 넣어준다.
    */

   
    public void Setup(Transform[] wayPoints)
    {
        moveEnemy = GetComponent<MoveEnemy>();
        animator = GetComponent<Animator>();


        wayPointCount = wayPoints.Length;
        this.wayPoints = new Transform[wayPointCount];
        this.wayPoints = wayPoints;

        transform.position = wayPoints[currentIndex].position;

        StartCoroutine(EMove());
    }

   
    /*
    EMove코루틴
    나의 위치와 현재 wayPoints의 거리가 0.02*speed보다 작다면
    다음위치로 NextMove
    */
    private IEnumerator EMove()
    {
        NextMove();
        while(true)
        {
            if(Vector3.Distance(transform.position,wayPoints[currentIndex].position)<0.02f * moveEnemy.MoveSpeed)
            {
                NextMove();

            }
            yield return null;
        }
    }
    
    /*
    NextMove
    현재의 인덱스(wayPoints)가 전체 카운트-1(0부터시작하니까)보다 작을때
    지금 인덱스 포지션으로 바꿔주고 현재인덱스 증가
    그리고 direction에 방금바꿔준 인덱스포지션(다음 이동할 포인트)에서 내 위치를 빼주고 normalized
    MoveTo실행

    else일땐 마지막점에 도달 한거니까 destroy
    */
    private void NextMove()
    {
        if(currentIndex < wayPointCount-1)
        {
            transform.position = wayPoints[currentIndex].position;
            currentIndex++;
            Vector3 direction = (wayPoints[currentIndex].position - transform.position).normalized;
            //다음 움직임 호출시... 그 떄긔 방향값(x,y)에 따라 애니메이션 바꿔줌....
        if(direction.y < 0)
        {
            animator.SetInteger("Dir",1);
        }
        if(direction.y >0 )
        {
            animator.SetInteger("Dir",3);
        }
        if(direction.x > 0)
        {
            animator.SetInteger("Dir",2);
            
        }
        
            moveEnemy.moveTo(direction);
        }
        else
        {
            gameManager = GameObject.Find("GameManager");
            gameManager.GetComponent<GameManager>().Hit();
            Destroy(gameObject);
        }

    }

    //====================================따로 추가한 것===================
    public float HP = 100f; // 체력
    // 데미지를 받는 함수
    public void TakeDamage(float damageAmount)
    {
        //Debug.Log("Hit");
        HP -= damageAmount;

        if (HP <= 0)
        {
            Die();
        }
        
    }

    public void Die()
    {
        
        Destroy(gameObject);
        //gameObject.SetActive(false);
    }
    //public void Scoreup()
    //{
    //    score++;

    //    if(score >= 20)
    //    {
    //        TextContrl.instance.showSuccess();
    //    }
    //}

}
