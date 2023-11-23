using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    #region ���� �ߴ���
    // //public SpriteRenderer spriteRenderer;
    // //public Rigidbody2D Rigidbody2D;

    // public GameObject[] towers; // Ÿ������ �������� ������ �迭
    // public GameObject bulletPrefab;  // �߻��� �Ѿ� ������
    // public Transform firePoint; // �Ѿ��� �߻�� ��ġ
    // public GameObject fireBulletPrefab;    // �� �Ӽ� �Ѿ� ������
    // public GameObject waterBulletPrefab;   // �� �Ӽ� �Ѿ� ������
    // public GameObject grassBulletPrefab;   // Ǯ �Ӽ� �Ѿ� ������
    // public GameObject normalBulletPrefab;  // �븻 �Ӽ� �Ѿ� ������

    // public TowerType towertype; // Ÿ���� �Ӽ�

    // public float fireRate = 1f; // �߻� �ӵ�
    // private float nextFireTime = 0f; // ���� �߻� �ð�
    //// public float bulletSpeed = 10f;
    // public float damage = 100f;


    // void Start()
    // {
    //     //spriteRenderer.GetComponent<SpriteRenderer>();
    //     //Rigidbody2D.GetComponent<Rigidbody2D>();
    // }
    // void Update()
    // {
    //     if (Time.time >= nextFireTime)
    //     {
    //         Shoot();
    //         nextFireTime = Time.time + 1f / fireRate;
    //     }
    // }

    // void Shoot()
    // {
    //     GameObject bulletPrefab = GetBulletPrefab(); // �Ӽ��� ���� �߻��� �Ѿ� ������ ��������

    //     if (bulletPrefab != null)
    //     {

    //         GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);

    //         //Rigidbody2D bulletRb = bullet.GetComponent<Rigidbody2D>();
    //         Bullet bulletScript = bullet.GetComponent<Bullet>();

    //         if (/*bulletRb*/bulletScript != null)
    //         {
    //             // Enemy �±׸� ���� ������Ʈ�� ã��
    //             GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

    //             // Ÿ���� ���� ����� ���� ã�� , ����, �� ����� ���� ã���� ������
    //             if (enemies.Length > 0)
    //             {
    //                 GameObject closestEnemy = enemies[0];
    //                 float closestDistance = Vector2.Distance(transform.position, closestEnemy.transform.position);

    //                 foreach (GameObject enemy in enemies)
    //                 {
    //                     float distance = Vector2.Distance(transform.position, enemy.transform.position);
    //                     if (distance < closestDistance)
    //                     {
    //                         closestEnemy = enemy;
    //                         closestDistance = distance;
    //                     }
    //                 }

    //                 Debug.Log("����� �� " + closestEnemy.transform.position);
    //                 // �Ѿ��� closestEnemy ������ �߻�
    //                 //Vector2 direction = (closestEnemy.transform.position - bullet.transform.position).normalized;
    //                 //bulletRb.velocity = direction * bulletSpeed;

    //                 //Debug.Log("�ӷ� : " + bulletSpeed);
    //                 //Debug.Log("����" +direction);
    //                 bulletScript.SetTarget(closestEnemy.transform);
    //             }
    //         }

    //     }
    // }

    // GameObject GetBulletPrefab()
    // {
    //     switch (towertype)
    //     {
    //         case TowerType.Fire:
    //             return fireBulletPrefab;
    //         case TowerType.Water:
    //             return waterBulletPrefab;
    //         case TowerType.Grass:
    //             return grassBulletPrefab;
    //         case TowerType.Normal:
    //             return normalBulletPrefab;
    //         default:
    //             return null;
    //     }
    // }
    // public void OnTriggerEnter2D(Collider2D collision)
    // {
    //     if (collision.CompareTag("Enemy"))
    //     {
    //         Enemy enemy = collision.GetComponent<Enemy>();

    //         if (enemy != null)
    //         {
    //             enemy.TakeDamage(damage);
    //         }
    //     }

    //         Destroy(gameObject);



    // }
    // ��� shoot�Լ��� ��ĥ�� �ִ���, enemy�� �±��߰��ϱ�
    //�Ҹ� ��ũ��Ʈ�� ���⿡ ����������

    #endregion

    #region ���� �ϴ°�
    public GameObject bulletPrefab; // �߻�� �Ѿ� ������
    public Transform firePoint; // �Ѿ��� �߻�� ��ġ
    public float rotationSpeed = 5f; // Ÿ���� ȸ�� �ӵ�
    public float attackRange = 10f; // Ÿ���� ���� ����
    public int maxBulletCount = 30; // �ִ� �Ѿ� ��

    private GameObject targetEnemy; // ���� ���� ���� ��
    private List<GameObject> bulletList = new List<GameObject>(); // ������ �Ѿ��� ���� ����Ʈ

    void Start()
    {
        // �ʱ⿡ �Ѿ� �������� ������� �Ѿ��� �����Ͽ� Ÿ���� �ڽ����� �߰���
        for (int i = 0; i < maxBulletCount; i++)
        {
            GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            bullet.SetActive(false); // ó������ ��� �Ѿ��� ��Ȱ��ȭ ���·� ����
            bullet.transform.SetParent(transform); // �Ѿ��� Ÿ���� �ڽ����� ����
            bulletList.Add(bullet); // ����Ʈ�� �Ѿ� �߰�
        }
    }

    void Update()
    {
        FindTargetEnemy(); // ������ �� ã��

        if (targetEnemy != null)
        {
            RotateTower(); // ���� ���� Ÿ�� ȸ��
            FireBullet(); // �Ѿ� �߻�
        }
    }

    void FindTargetEnemy()
    {
        GameObject[] enemies = GameObject.FindObjectsOfType<GameObject>(); // Scene���� ��� GameObject ã��
        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;

        foreach (GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if (distanceToEnemy < shortestDistance && distanceToEnemy <= attackRange)
            {
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy;
            }
        }

        targetEnemy = nearestEnemy; // ���� ����� ���� ���� ������� ����
    }

    void RotateTower()
    {
        if (targetEnemy != null)
        {
            Vector3 direction = targetEnemy.transform.position - transform.position;
            Quaternion lookRotation = Quaternion.LookRotation(direction);
            Vector3 rotation = Quaternion.Lerp(transform.rotation, lookRotation, Time.deltaTime * rotationSpeed).eulerAngles;
            transform.rotation = Quaternion.Euler(0f, rotation.y, 0f);
        }
    }

    void FireBullet()
    {
        foreach (GameObject bullet in bulletList)
        {
            if (!bullet.activeInHierarchy) // Ȱ��ȭ���� ���� �Ѿ��� ã�Ƽ� �߻�
            {
                bullet.transform.position = firePoint.position;
                bullet.transform.rotation = firePoint.rotation;
                bullet.SetActive(true); // �Ѿ� Ȱ��ȭ�Ͽ� �߻�

                Bullet bulletScript = bullet.GetComponent<Bullet>();
                if (bulletScript != null && targetEnemy != null)
                {
                    bulletScript.Seek(targetEnemy.transform); // �߻�� �Ѿ��� ������ �� ����
                }
                return; // �߻� �� �ٷ� ��ȯ
            }
        }
    }

    #endregion
}
