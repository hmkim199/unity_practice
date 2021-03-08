using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject boxPrefab;

    private void Awake()
    {
        // Instantiate : original 게임 오브젝트(프리팹)를 완전히 동일하게 복제해서 생성.
        // Instantiate(boxPrefab);

        // 프리팹, 위치, 회전값 설정 가능
        // Instantiate(boxPrefab, new Vector3(3, 3, 0), Quaternion.identity);
        // Instantiate(boxPrefab, new Vector3(-1, -2, 0), Quaternion.identity);

        Quaternion rotation = Quaternion.Euler(0, 0, 45);
        // Instantiate(boxPrefab, new Vector3(2, 1, 0), rotation);

        // 방금 생성된 복제 정보 받아서 설정하기
        GameObject clone = Instantiate(boxPrefab, Vector3.zero, rotation);

        // 방금 생성된 게임 오브젝트의 이름 변경
        clone.name = "Box001";
        // 방금 생성된 게임 오브젝트의 색상 변경
        clone.GetComponent<SpriteRenderer>().color = Color.black;
        // 방금 생성된 게임 오브젝트의 위치 변경
        clone.transform.position = new Vector3(2, 1, 0);
        // 크기 변경
        clone.transform.localScale = new Vector3(3, 2, 1);
    }
}
