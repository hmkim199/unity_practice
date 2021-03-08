using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerEvent : MonoBehaviour
{
    [SerializeField]
    private GameObject moveObject;
    [SerializeField]
    private Vector3 moveDirection;
    private float moveSpeed;

    private void Awake()
    {
        moveSpeed = 5.0f;
    }

    // 충돌이 일어나는 순간 1회 호출
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // moveObject 오브젝트의 색상을 검은색(Color.black)으로 설정한다.
        moveObject.GetComponent<SpriteRenderer>().color = Color.black;
    }

    // 충돌이 유지되는 동안 매 프레임 호출
    private void OnTriggerStay2D(Collider2D collision)
    {
        // moveObject 오브젝트를 moveDirection 방향으로 이동한다.
        moveObject.transform.position += moveDirection * moveSpeed * Time.deltaTime; 
    }

    // 충돌이 종료되는 순간 1회 호출
    private void OnTriggerExit2D(Collider2D collision)
    {
        // moveObject 오브젝트의 색상을 흰색(Color.white)으로 설정한다
        moveObject.GetComponent<SpriteRenderer>().color = Color.white;
        // moveObject 오브젝트의 위치를 (0, 4, 0)으로 설정한다.
        moveObject.transform.position = new Vector3(0, 4, 0);
    }

}
