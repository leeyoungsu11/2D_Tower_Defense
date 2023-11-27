using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    [SerializeField]
    public float attackRange = 0; // Ÿ���� ���� ����

    private CircleCollider2D colrenge;
    public GameObject bulletPrefab; // �߻�� �Ѿ� ������
    public Transform firePoint; // �Ѿ��� �߻�� ��ġ
    public float rotationSpeed = 10f; // Ÿ���� ȸ�� �ӵ�
    public int maxBulletCount = 30; // �ִ� �Ѿ� ��
    Vector3 direction;

    
    private List<GameObject> Enemyes;
    private GameObject targetEnemy; // ���� ���� ���� ��
    private List<GameObject> bulletList = new List<GameObject>(); // ������ �Ѿ��� ���� ����Ʈ

    public Coroutine cor= null ;
    void Start()
    {
        // �Ѿ� �������� ������� �Ѿ��� �����Ͽ� Ÿ���� �ڽ����� �߰���
        for (int i = 0; i < maxBulletCount; i++)
        {
            GameObject bullet = Instantiate(bulletPrefab, new Vector3(0,0,0), firePoint.rotation);
            bullet.SetActive(false); // ó������ ��� �Ѿ��� ��Ȱ��ȭ ���·� ����
            bulletList.Add(bullet); // ����Ʈ�� �Ѿ� �߰�
        }

        Enemyes = new List<GameObject>();
        colrenge = GetComponent<CircleCollider2D>();
    }

    void Update()
    {
        if(Enemyes.Count >= 1)
        {
            FindTargetEnemy(); // ������ �� ã��
        }
        

        if (targetEnemy != null)
        {
            RotateTower(); // ���� ���� Ÿ�� ȸ��        
        }
    }

   
    void FindTargetEnemy()
    {
        colrenge.radius = attackRange;

        GameObject nearestEnemy = null;

        float distanceToEnemy = Vector3.Distance(transform.position, Enemyes[0].transform.position);

        if (distanceToEnemy <=  colrenge.radius+0.4f)
        {
            nearestEnemy = Enemyes[0].gameObject;
        }
        targetEnemy = nearestEnemy; // ���� ����� ���� ���� ������� ����

    }

    void RotateTower()
    {
        if (targetEnemy != null)
        {
            direction = targetEnemy.transform.position - transform.position;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
            if (cor == null)
            {
                cor = StartCoroutine(Firetime());
            }
        }

    }

    IEnumerator Firetime()
    {
        yield return new WaitForSeconds(0.5f);

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
                break;
            }
            
        }
        cor = null;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Enemy"))
        {
            Enemyes.Add(collision.gameObject);
        }
    }
    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Enemyes.Remove(collision.gameObject);
        }
    }
}
