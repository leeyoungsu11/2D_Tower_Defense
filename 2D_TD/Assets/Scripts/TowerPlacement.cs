using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TowerPlacement : MonoBehaviour
{
    public GameObject Towers; // 타워 프리팹 저장소
    public GameObject[] TowerPoint;
    public GameObject TowerSet;
    public GameObject UnitSet;
    public Tower Tower_Up;

    private GameObject choiceTowerPrefab;  //선택된 타워 프리팹
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
                        game.GetComponent<GameManager>().SetGold(2); // 타워 구매 후 돈 차감
                        hit.collider.gameObject.SetActive(false);
                    }
                    else
                    {
                        Debug.Log("돈이 부족합니다.");
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
                        Debug.Log("돈이 부족합니다.");
                    }
                }
            }
            
        }
    }

    void CreateNewTower(Vector3 position)  // 새로운 타워를 마우스 클릭 위치에 생성하는 함수
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
