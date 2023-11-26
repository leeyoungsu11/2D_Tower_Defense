using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    #region 이전 사용 스크립트
    // //private Transform target;
    ////public SpriteRenderer spriteRenderer;
    ////public Rigidbody2D Rigidbody2D;
    // //public CircleCollider2D CircleCollider2D;

    // public float bulletSpeed = 100f;
    // public float damage = 100f;
    // //public float bulletSpeed = 10f; // 총알 속도

    // Transform enemy;
    // Vector2 dir;
    // bool isStart = false;

    // private void Start()
    // {
    //     //spriteRenderer.GetComponent<SpriteRenderer>();
    //     //Rigidbody2D.GetComponent<Rigidbody2D>();
    //     //CircleCollider2D.GetComponent<CircleCollider2D>();

    // }

    // public void SetTarget(Transform tr)
    // {
    //     enemy = tr;
    //     dir = (tr.position - transform.position).normalized;
    //         isStart = true;
    // }
    // void Update()
    // {
    //     if (isStart)
    //     {
    //         MoveBullet();
    //     }        
    // }

    // void MoveBullet()
    // {
    //     transform.Translate(/*Vector2.left*/dir.normalized * bulletSpeed * Time.deltaTime);

    // }

    //void OnTriggerEnter2D(Collider2D collision)
    //{

    //    Destroy(gameObject); // 총알 파괴
    //}
    //public void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if (collision.CompareTag("Enemy"))
    //    {
    //        Enemy enemy = collision.GetComponent<Enemy>();

    //        if (enemy != null)
    //        {
    //            enemy.TakeDamage(damage);
    //        }
    //    }

    //    Destroy(gameObject);
    //}
    //public void Seek(Transform _target)
    //{
    //    target = _target;
    //}
    #endregion

    #region 뉴 스크립트
    public float bulletSpeed = 100f; // 총알의 이동 속도

    public Transform targetEnemy; // 추적 중인 적
    
    
    void Update()
    {
        if (targetEnemy != null)
        {
            MoveBullet(); // 총알 이동

            if (!IsBulletInView()) // 카메라 영역 밖으로 나가면 총알 재활용을 위해 초기화
            {
                ResetBullet();
            }
        }
        else
        {
            ResetBullet(); // 추적 중인 적이 없으면 총알 재활용을 위해 초기화
        }
    }

    void MoveBullet()
    {
        transform.Translate(transform.up * bulletSpeed * Time.deltaTime, Space.World); // 총알 이동
    }

    bool IsBulletInView()
    {
        Vector3 screenPoint = Camera.main.WorldToViewportPoint(transform.position);
        return screenPoint.x >= 0 && screenPoint.x <= 1 && screenPoint.y >= 0 && screenPoint.y <= 1 && screenPoint.z > 0;
    }

    public void Seek(Transform target)
    {
        targetEnemy = target; // 총알이 추적할 적 설정
    }

    void ResetBullet()
    {
        targetEnemy = null; // 적 추적 설정 초기화
        gameObject.SetActive(false); // 총알을 비활성화하여 재사용을 위해 풀에 반환
    }

    

    private void OnTriggerEnter2D(Collider2D other )
    {        
        if (other.CompareTag("Enemy"))
        {
            //other.transform.GetComponent<SpriteRenderer>().color = Color.red;
            //Debug.Log(other.gameObject.name);
            ResetBullet(); // 적과 충돌하면 총알을 재활용을 위해 초기화
        }
    }
    
    //총알이 먼저 한발 나가는거, 타겟 전에 다른 에너미가 있어서 맞아버리는거 수정해야함//

    #endregion
}
