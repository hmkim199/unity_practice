using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroySample : MonoBehaviour
{
    [SerializeField]
    private GameObject playerObject;

    private void Awake()
    {
        // playerObject 게임 오브젝트의 "PlayerController" 컴포넌트 삭제
        // 컴포넌트도 삭제가 가능하다는 것을 보여주기 위해 이를 사용했지만
        // playerObject.GetComponent<PlayerController>().enabled = false;와 같이 컴포넌트를 삭제하지 않고 꺼두는 것을 더 권장한다.
        // Destroy(playerObject.GetComponent<PlayerController>());

        // playerObject 게임 오브젝트를 2초 뒤에 삭제
        Destroy(playerObject, 2.0f);
    }
}
