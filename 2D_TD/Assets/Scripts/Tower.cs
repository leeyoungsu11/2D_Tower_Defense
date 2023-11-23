using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    public GameObject[] towers; // Ÿ������ �������� ������ �迭
    public GameObject bulletPrefab;  // �߻��� �Ѿ� ������
    public Transform firePoint; // �Ѿ��� �߻�� ��ġ
    public GameObject fireBulletPrefab;    // �� �Ӽ� �Ѿ� ������
    public GameObject waterBulletPrefab;   // �� �Ӽ� �Ѿ� ������
    public GameObject grassBulletPrefab;   // Ǯ �Ӽ� �Ѿ� ������
    public GameObject normalBulletPrefab;  // �븻 �Ӽ� �Ѿ� ������

    public TowerType towertype; // Ÿ���� �Ӽ�

    public float fireRate = 1f; // �߻� �ӵ�
    private float nextFireTime = 0f; // ���� �߻� �ð�
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
        GameObject bulletPrefab = GetBulletPrefab(); // �Ӽ��� ���� �߻��� �Ѿ� ������ ��������

        if (bulletPrefab != null)
        {
            GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);

            Rigidbody2D bulletRb = bullet.GetComponent< Rigidbody2D >();
            if (bulletRb != null)
            {
                // Enemy �±׸� ���� ������Ʈ�� ã��
                GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

                // Ÿ���� ���� ����� ���� ã�� , ����, �� ����� ���� ã���� ������
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

                    // �Ѿ��� closestEnemy ������ �߻�
                    Vector2 direction = (closestEnemy.transform.position - bullet.transform.position).normalized;
                    bulletRb.velocity = direction * bulletSpeed;
                }
            }
            else
            {
                Debug.LogWarning(" �Ѿ��� �߰ߵ��� �ʾҽ��ϴ�."); //��� �޽���
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
// ��� shoot�Լ��� ��ĥ�� �ִ���, enemy�� �±��߰��ϱ�
//�Ҹ� ��ũ��Ʈ�� ���⿡ ����������