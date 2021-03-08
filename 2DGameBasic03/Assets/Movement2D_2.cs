﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement2D_2 : MonoBehaviour
{
    private float moveSpeed = 5.0f;
    private Vector3 moveDirection;

    public void Setup(Vector3 direction) {
        moveDirection = direction;
    }

    private void Update()
    {
        // 새로운 위치 = 현재위치 + 방향 * 속도
        transform.position += moveDirection * moveSpeed * Time.deltaTime;
    }
}
