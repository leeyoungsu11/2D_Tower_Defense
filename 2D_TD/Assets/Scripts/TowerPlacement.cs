using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerPlacement : MonoBehaviour
{
    public GameObject Towers; // Ÿ�� ������ �����
    public GameObject[] TowerPoint;
    private bool isDragging = false; // �巡�� ������
    private GameObject choiceTowerPrefab;  //���õ� Ÿ�� ������
    private GameObject game;
    public int money = 0;
    bool isClick = false;

    void Start()
    {
        game = GameObject.Find("GameManager");
        
    }
    void Update()
    {
        //Debug.Log(isClick);
        money = game.GetComponent<GameManager>().GetGold();
        if (Input.GetMouseButtonDown(0)&& isClick == false)
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            //RaycastHit2D hit = Physics2D.Raycast(Input.mousePosition, Vector2.zero);

            if (hit.collider != null && hit.collider.CompareTag("TowerGound")) // �浹�� ������Ʈ�� Ÿ���� ��� (Ÿ���� ��ĥ���)
            {
                Debug.Log("Ÿ����");

                choiceTowerPrefab = hit.collider.gameObject;

                if (money >= 10) 
                {

                    Vector3 towerVec = choiceTowerPrefab.transform.position;
                    Debug.Log(towerVec);
                    CreateNewTower(towerVec);
                    //Debug.Log("Ÿ������");
                    game.GetComponent<GameManager>().SetGold(10); // Ÿ�� ���� �� �� ����
                    //isClick = true;

                }
                else
                {
                    Debug.Log("���� �����մϴ�.");
                    //isClick = true;
                }
            }
        }

        //if (isDragging && Input.GetMouseButton(0)) // Ÿ���� �巡�� ���� ��
        //{
        //    Vector3 newPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //    newPosition.z = 0f; // Z ���� �����Ͽ� ȭ�� ������ ����

        //    choiceTowerPrefab.transform.position = newPosition;
        //}

        //if (isDragging && Input.GetMouseButtonUp(0)) // �巡�׸� ���� ��
        //{
        //    isDragging = false;
        //    choiceTowerPrefab = null;
        //}
    }

    void CreateNewTower(Vector3 position)  // ���ο� Ÿ���� ���콺 Ŭ�� ��ġ�� �����ϴ� �Լ�
    {
        GameObject newTower = Instantiate(Towers, position,Quaternion.identity);
        Tower tower = newTower.GetComponent<Tower>();
        tower.Setup(position);
    }
}
