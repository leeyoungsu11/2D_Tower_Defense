using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TowerPlacement : MonoBehaviour
{
    public GameObject Towers; // Ÿ�� ������ �����
    public GameObject[] TowerPoint;
    public GameObject TowerSet;
    public GameObject UnitSet;
    public Tower Tower_Up;

    private GameObject choiceTowerPrefab;  //���õ� Ÿ�� ������
    private UnitSet choiceUnit;
    private GameObject game;
    private int money = 0;

    void Start()
    {
        game = GameObject.Find("GameManager");
        
    }
    void Update()
    {

        //Debug.Log(isClick);
        money = game.GetComponent<GameManager>().GetGold();
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

            if(hit.collider != null)
            {
                if (hit.collider.CompareTag("TowerGound"))
                {

                    if (money >= 200)
                    {
                        choiceTowerPrefab = hit.collider.gameObject;
                        Vector3 towerVec = choiceTowerPrefab.transform.position;
                        CreateNewTower(towerVec);
                        game.GetComponent<GameManager>().SetGold(2); // Ÿ�� ���� �� �� ����
                        hit.collider.gameObject.SetActive(false);
                    }
                    else
                    {
                        Debug.Log("���� �����մϴ�.");
                    }
                }
                else if (hit.collider.CompareTag("Unit"))
                {
                    if(money >= 150)
                    {
                        choiceUnit = hit.collider.gameObject.GetComponent<UnitSet>();
                        choiceUnit.GetComponent<UnitSet>().Upgrade();
                        game.GetComponent<GameManager>().SetGold(150);

                    }
                    else
                    {
                        Debug.Log("���� �����մϴ�.");
                    }
                }
            }
            
        }
    }

    void CreateNewTower(Vector3 position)  // ���ο� Ÿ���� ���콺 Ŭ�� ��ġ�� �����ϴ� �Լ�
    {
        GameObject newTowerSet = Instantiate(TowerSet, position + Vector3.up, Quaternion.identity);
        TowerSet towerSet = newTowerSet.GetComponent<TowerSet>();

        GameObject newUnitSet = Instantiate(UnitSet, position + Vector3.up, Quaternion.identity);
        UnitSet unitSet = newUnitSet.GetComponent<UnitSet>();
        unitSet.SetUp();

        GameObject newTower = Instantiate(Towers, position+Vector3.up, Quaternion.identity);
        Tower tower = newTower.GetComponent<Tower>();
        tower.Setup(position, unitSet);

    }
 
}
