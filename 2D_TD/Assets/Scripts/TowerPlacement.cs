using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerPlacement : MonoBehaviour
{
    public GameObject[] Towers; // Ÿ�� ������ �����
    private bool isDragging = false; // �巡�� ������
    private GameObject choiceTowerPrefab;  //���õ� Ÿ�� ������

    public int money = 100;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
           
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            if (hit.collider != null && hit.collider.CompareTag("Tower")) // �浹�� ������Ʈ�� Ÿ���� ��� (Ÿ���� ��ĥ���)
            {
                isDragging = true;
                choiceTowerPrefab = hit.collider.gameObject;
            }
            else
            {
                
                if (money >= 10) // ���콺 Ŭ�� ��ġ�� ���ο� Ÿ�� ����
                {
                    CreateNewTower(Camera.main.ScreenToWorldPoint(Input.mousePosition));
                    money -= 10; // Ÿ�� ���� �� �� ����
                }
                else
                {
                    Debug.Log("���� �����մϴ�.");
                }
            }
        }

        if (isDragging && Input.GetMouseButton(0)) // Ÿ���� �巡�� ���� ��
        {
            Vector3 newPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            newPosition.z = 0f; // Z ���� �����Ͽ� ȭ�� ������ ����

            choiceTowerPrefab.transform.position = newPosition;
        }

        if (isDragging && Input.GetMouseButtonUp(0)) // �巡�׸� ���� ��
        {
            isDragging = false;
            choiceTowerPrefab = null;
        }
    }
    
    void CreateNewTower(Vector3 position)  // ���ο� Ÿ���� ���콺 Ŭ�� ��ġ�� �����ϴ� �Լ�
    {
        if (Towers.Length > 0)
        {
            // ù ��° Ÿ�� �������� �����ͼ� ���� ����
            GameObject newTower = Instantiate(Towers[0], position, Quaternion.identity);
            
        }
    }
}
