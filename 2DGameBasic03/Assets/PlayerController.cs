using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private KeyCode keyCodeFire = KeyCode.Space;
    [SerializeField]
    private GameObject bulletPrefab;
    private float moveSpeed = 3.0f;
    private Vector3 lastMoveDirection = Vector3.right; // 더 이상 이동하지 않았을 경우 마지막으로 이동한 방향 저장

    private void Update()
    {
        // 플레이어 오브젝트 이동
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        transform.position += new Vector3(x, y, 0) * moveSpeed * Time.deltaTime;

        // 마지막에 입력된 방향키의 방향을 총알의 발사 방향으로 활용
        if (x != 0 || y != 0) {
            lastMoveDirection = new Vector3(x, y, 0);
        }

        // 플레이어 오브젝트 총알 발사
        if (Input.GetKeyDown(keyCodeFire)) {
            GameObject clone = Instantiate(bulletPrefab, transform.position, Quaternion.identity);

            clone.name = "Bullet";
            clone.transform.localScale = Vector3.one * 0.5f;
            clone.GetComponent<SpriteRenderer>().color = Color.red;

            clone.GetComponent<Movement2D_2>().Setup(lastMoveDirection);
        }
    }
}
