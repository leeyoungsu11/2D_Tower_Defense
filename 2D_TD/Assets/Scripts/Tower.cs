using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    public GameObject[] towers; // 타워들의 프리팹을 저장할 배열
    public GameObject bulletPrefab;  // 발사할 총알 프리팹
    public Transform firePoint; // 총알이 발사될 위치
    public GameObject fireBulletPrefab;    // 불 속성 총알 프리팹
    public GameObject waterBulletPrefab;   // 물 속성 총알 프리팹
    public GameObject grassBulletPrefab;   // 풀 속성 총알 프리팹
    public GameObject normalBulletPrefab;  // 노말 속성 총알 프리팹

    public TowerType towertype; // 타워의 속성

    public float fireRate = 1f; // 발사 속도
    private float nextFireTime = 0f; // 다음 발사 시간
    public float bulletSpeed = 1f;
    public float damage = 10f;


    void Update()
    {
        if (Time.time >= nextFireTime)
        {
            Shoot();
            nextFireTime = Time.time + 1f / fireRate;
        }
    }

    void Shoot()
    {
        GameObject bulletPrefab = GetBulletPrefab(); // 속성에 따라 발사할 총알 프리팹 가져오기

        if (bulletPrefab != null)
        {
            GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);

            Rigidbody2D bulletRb = bullet.GetComponent< Rigidbody2D >();
            if (bulletRb != null)
            {
                // Enemy 태그를 가진 오브젝트를 찾음
                GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

                // 타워와 가장 가까운 적을 찾음 , 이후, 더 가까운 적을 찾으면 공격함
                if (enemies.Length > 0)
                {
                    GameObject closestEnemy = enemies[0];
                    float closestDistance = Vector2.Distance(transform.position, closestEnemy.transform.position);

                    foreach (GameObject enemy in enemies)
                    {
                        float distance = Vector2.Distance(transform.position, enemy.transform.position);
                        if (distance < closestDistance)
                        {
                            closestEnemy = enemy;
                            closestDistance = distance;
                        }
                    }

                    // 총알을 closestEnemy 쪽으로 발사
                    Vector2 direction = (closestEnemy.transform.position - bullet.transform.position).normalized;
                    bulletRb.velocity = direction * bulletSpeed;
                }
            }
            else
            {
                Debug.LogWarning(" 총알이 발견되지 않았습니다."); //경고 메시지
            }
        }
    }
    private void Start()
    {
        
    }
    GameObject GetBulletPrefab()
    {
        switch (towertype)
        {
            case TowerType.Fire:
                return fireBulletPrefab;
            case TowerType.Water:
                return waterBulletPrefab;
            case TowerType.Grass:
                return grassBulletPrefab;
            case TowerType.Normal:
                return normalBulletPrefab;
            default:
                return null;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            Enemy enemy = collision.GetComponent<Enemy>();

            if (enemy != null)
            {
                enemy.TakeDamage(damage);
            }
        }
        Destroy(gameObject);
    }

}
// 얘랑 shoot함수랑 합칠수 있는지, enemy에 태그추가하기
//불릿 스크립트가 여기에 쓰여져버림