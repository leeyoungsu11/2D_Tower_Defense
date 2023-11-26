using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    #region ���� ��� ��ũ��Ʈ
    // //private Transform target;
    ////public SpriteRenderer spriteRenderer;
    ////public Rigidbody2D Rigidbody2D;
    // //public CircleCollider2D CircleCollider2D;

    // public float bulletSpeed = 100f;
    // public float damage = 100f;
    // //public float bulletSpeed = 10f; // �Ѿ� �ӵ�

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

    //    Destroy(gameObject); // �Ѿ� �ı�
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

    #region �� ��ũ��Ʈ
    public float bulletSpeed = 100f; // �Ѿ��� �̵� �ӵ�

    public Transform targetEnemy; // ���� ���� ��
    
    
    void Update()
    {
        if (targetEnemy != null)
        {
            MoveBullet(); // �Ѿ� �̵�

            if (!IsBulletInView()) // ī�޶� ���� ������ ������ �Ѿ� ��Ȱ���� ���� �ʱ�ȭ
            {
                ResetBullet();
            }
        }
        else
        {
            ResetBullet(); // ���� ���� ���� ������ �Ѿ� ��Ȱ���� ���� �ʱ�ȭ
        }
    }

    void MoveBullet()
    {
        transform.Translate(transform.up * bulletSpeed * Time.deltaTime, Space.World); // �Ѿ� �̵�
    }

    bool IsBulletInView()
    {
        Vector3 screenPoint = Camera.main.WorldToViewportPoint(transform.position);
        return screenPoint.x >= 0 && screenPoint.x <= 1 && screenPoint.y >= 0 && screenPoint.y <= 1 && screenPoint.z > 0;
    }

    public void Seek(Transform target)
    {
        targetEnemy = target; // �Ѿ��� ������ �� ����
    }

    void ResetBullet()
    {
        targetEnemy = null; // �� ���� ���� �ʱ�ȭ
        gameObject.SetActive(false); // �Ѿ��� ��Ȱ��ȭ�Ͽ� ������ ���� Ǯ�� ��ȯ
    }

    

    private void OnTriggerEnter2D(Collider2D other )
    {        
        if (other.CompareTag("Enemy"))
        {
            //other.transform.GetComponent<SpriteRenderer>().color = Color.red;
            //Debug.Log(other.gameObject.name);
            ResetBullet(); // ���� �浹�ϸ� �Ѿ��� ��Ȱ���� ���� �ʱ�ȭ
        }
    }
    
    //�Ѿ��� ���� �ѹ� �����°�, Ÿ�� ���� �ٸ� ���ʹ̰� �־ �¾ƹ����°� �����ؾ���//

    #endregion
}
