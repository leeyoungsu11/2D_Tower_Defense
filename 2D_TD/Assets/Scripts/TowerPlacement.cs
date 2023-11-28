using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerPlacement : MonoBehaviour
{
    public GameObject Towers; // 타워 프리팹 저장소
    public GameObject[] TowerPoint;
    public GameObject TowerSet;
    private bool isDragging = false; // 드래그 중인지
    private GameObject choiceTowerPrefab;  //선택된 타워 프리팹
    private GameObject game;
    private int money = 0;
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
                    game.GetComponent<GameManager>().SetGold(50); // 타워 구매 후 돈 차감
                    Debug.Log(money);
                }
                else
                {
                    Debug.Log("돈이 부족합니다.");
                }
            }
        }
    }

    void CreateNewTower(Vector3 position)  // 새로운 타워를 마우스 클릭 위치에 생성하는 함수
    {
        GameObject newTower = Instantiate(Towers, position,Quaternion.identity);
        Tower tower = newTower.GetComponent<Tower>();
        tower.Setup(position);
        GameObject newTowerSet = Instantiate(TowerSet, position + Vector3.up, Quaternion.identity);

    }
}
