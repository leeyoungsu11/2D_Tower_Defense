using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerPlacement : MonoBehaviour
{
    public GameObject Towers; // 타워 프리팹 저장소
    public GameObject[] TowerPoint;
    private bool isDragging = false; // 드래그 중인지
    private GameObject choiceTowerPrefab;  //선택된 타워 프리팹
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

            if (hit.collider != null && hit.collider.CompareTag("TowerGound")) // 충돌한 오브젝트가 타워인 경우 (타워가 겹칠경우)
            {
                Debug.Log("타워땅");

                choiceTowerPrefab = hit.collider.gameObject;

                if (money >= 10) 
                {

                    Vector3 towerVec = choiceTowerPrefab.transform.position;
                    Debug.Log(towerVec);
                    CreateNewTower(towerVec);
                    //Debug.Log("타워생성");
                    game.GetComponent<GameManager>().SetGold(10); // 타워 구매 후 돈 차감
                    //isClick = true;

                }
                else
                {
                    Debug.Log("돈이 부족합니다.");
                    //isClick = true;
                }
            }
        }

        //if (isDragging && Input.GetMouseButton(0)) // 타워를 드래그 중일 때
        //{
        //    Vector3 newPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //    newPosition.z = 0f; // Z 축을 조정하여 화면 안으로 고정

        //    choiceTowerPrefab.transform.position = newPosition;
        //}

        //if (isDragging && Input.GetMouseButtonUp(0)) // 드래그를 끝낼 때
        //{
        //    isDragging = false;
        //    choiceTowerPrefab = null;
        //}
    }

    void CreateNewTower(Vector3 position)  // 새로운 타워를 마우스 클릭 위치에 생성하는 함수
    {
        GameObject newTower = Instantiate(Towers, position,Quaternion.identity);
        Tower tower = newTower.GetComponent<Tower>();
        tower.Setup(position);
    }
}
