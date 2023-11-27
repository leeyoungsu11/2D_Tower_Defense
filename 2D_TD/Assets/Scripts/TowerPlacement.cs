using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerPlacement : MonoBehaviour
{
    public GameObject Towers; // Ÿ�� ������ �����
    public GameObject[] TowerPoint;
    public GameObject TowerSet;
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

            if (hit.collider != null && hit.collider.CompareTag("TowerGound"))
            {
                choiceTowerPrefab = hit.collider.gameObject;

                if (money >= 100) 
                {

                    Vector3 towerVec = choiceTowerPrefab.transform.position;
                    CreateNewTower(towerVec);
                    game.GetComponent<GameManager>().SetGold(50); // Ÿ�� ���� �� �� ����
                    Debug.Log(money);
                }
                else
                {
                    Debug.Log("���� �����մϴ�.");
                }
            }
        }
    }

    void CreateNewTower(Vector3 position)  // ���ο� Ÿ���� ���콺 Ŭ�� ��ġ�� �����ϴ� �Լ�
    {
        GameObject newTower = Instantiate(Towers, position,Quaternion.identity);
        Tower tower = newTower.GetComponent<Tower>();
        tower.Setup(position);
        GameObject newTowerSet = Instantiate(TowerSet, position + Vector3.up, Quaternion.identity);

    }
}
