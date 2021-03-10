using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    // 게임 오브젝트가 1초에 Y축 기준으로 몇 도 회전할지 나타내는 변수
    public float rotationSpeed = 60f;
    
    void Update()
    {
        transform.Rotate(0f, rotationSpeed * Time.deltaTime, 0f);
    }
}
