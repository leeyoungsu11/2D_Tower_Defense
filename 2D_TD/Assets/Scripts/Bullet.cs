using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    //private Transform target;
   // public SpriteRenderer spriteRenderer;
   // public Rigidbody2D Rigidbody2D;
    //public CircleCollider2D CircleCollider2D;

    public float bulletSpeed = 1f;
    public float damage = 100f;
    //public float bulletSpeed = 10f; // ÃÑ¾Ë ¼Óµµ

    Transform enemy;
    Vector2 dir;
    bool isStart = false;

    private void Start()
    {
        //spriteRenderer.GetComponent<SpriteRenderer>();
        //Rigidbody2D.GetComponent<Rigidbody2D>();
        //CircleCollider2D.GetComponent<CircleCollider2D>();
       
    }

    public void SetTarget(Transform tr)
    {
        enemy = tr;
        dir = tr.position - transform.position;
            isStart = true;
    }
    void Update()
    {
        if (isStart)
        {
            MoveBullet();
        }        
    }

    void MoveBullet()
    {
        transform.Translate(/*Vector2.left*/dir * bulletSpeed * Time.deltaTime);

    }

    //void OnTriggerEnter2D(Collider2D collision)
    //{

    //    Destroy(gameObject); // ÃÑ¾Ë ÆÄ±«
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
}
