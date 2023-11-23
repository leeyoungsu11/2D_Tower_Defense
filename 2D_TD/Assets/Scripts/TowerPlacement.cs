using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerPlacement : MonoBehaviour
{
    public GameObject[] Towers; // 타워 프리팹 저장소
    private bool isDragging = false; // 드래그 중인지
    private GameObject choiceTowerPrefab;  //선택된 타워 프리팹

    public int money = 100;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
           
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            if (hit.collider != null && hit.collider.CompareTag("Tower")) // 충돌한 오브젝트가 타워인 경우 (타워가 겹칠경우)
            {
                isDragging = true;
                choiceTowerPrefab = hit.collider.gameObject;
            }
            else
            {
                
                if (money >= 10) // 마우스 클릭 위치에 새로운 타워 생성
                {
                    CreateNewTower(Camera.main.ScreenToWorldPoint(Input.mousePosition));
                    money -= 10; // 타워 구매 후 돈 차감
                }
                else
                {
                    Debug.Log("돈이 부족합니다.");
                }
            }
        }

        if (isDragging && Input.GetMouseButton(0)) // 타워를 드래그 중일 때
        {
            Vector3 newPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            newPosition.z = 0f; // Z 축을 조정하여 화면 안으로 고정

            choiceTowerPrefab.transform.position = newPosition;
        }

        if (isDragging && Input.GetMouseButtonUp(0)) // 드래그를 끝낼 때
        {
            isDragging = false;
            choiceTowerPrefab = null;
        }
    }
    
    void CreateNewTower(Vector3 position)  // 새로운 타워를 마우스 클릭 위치에 생성하는 함수
    {
        if (Towers.Length > 0)
        {
            // 첫 번째 타워 프리팹을 가져와서 씬에 생성
            GameObject newTower = Instantiate(Towers[0], position, Quaternion.identity);
            
        }
    }
}
