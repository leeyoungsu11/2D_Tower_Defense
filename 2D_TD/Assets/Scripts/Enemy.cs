using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Enemy : MonoBehaviour
{
    private int wayPointCount;
    private Transform[] wayPoints;
    private int currentIndex = 0;
    private MoveEnemy moveEnemy;

    public void Setup(Transform[] wayPoints)
    {
        moveEnemy = GetComponent<MoveEnemy>();

        wayPointCount = wayPoints.Length;
        this.wayPoints = new Transform[wayPointCount];
        this.wayPoints = wayPoints;

        transform.position = wayPoints[currentIndex].position;

        StartCoroutine(EMove());
    }

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

    private void NextMove()
    {
        if(currentIndex < wayPointCount-1)
        {
            transform.position = wayPoints[currentIndex].position;
            currentIndex++;
            Vector3 direction = (wayPoints[currentIndex].position - transform.position).normalized;
            moveEnemy.moveTo(direction);
        }
        else
        {
            Destroy(gameObject);
        }

    }
}
