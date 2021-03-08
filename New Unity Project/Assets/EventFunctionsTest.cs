using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventFunctionsTest : MonoBehaviour
{
    // Awake 함수 : 현재 씬에서 게임 오브젝트가 활성화 되어 있을 때 1회 호출. 데이터를 초기화 하는 용도로 사용.
    // 컴포넌트가 비활성화 상태여도 게임 오브젝트가 활성화 되어 있으면 호출됨.
    private void Awake()
    {
        Debug.Log("Awake 함수가 실행되었습니다.");
    }

    // Start 함수 : 현재 씬에서 게임 오브젝트와 컴포넌트가 모두 활성화 되어 있을 때 1회 호출.
    // 데이터를 초기화하는 용도로 사용. 첫 번째 업데이트 함수가 실행되기 직전에 호출.
    // 초기화 함수 호출 순서 : Awake() -> OnEnable() -> Start()
    private void Start()
    {
        Debug.Log("Start 함수가 실행되었습니다.");
    }

    // OnEnable 함수 : 컴포넌트가 비활성화 되었다가 활성화 될 때 마다 1회 호출.
    private void OnEnable()
    {
        Debug.Log("OnEnable 함수가 실행되었습니다.");
    }

    // Update 함수 : 현재 씬이 실행된 후 컴포넌트가 활성화되어 있을 때 매 프레임마다 호출.
    private void Update()
    {
        Debug.Log("Update 함수가 실행되었습니다.");
    }

    // LateUpdate 함수 : 현재 씬에 존재하는 모든 게임 오브젝트의 Update 함수가 1회 호출된 후 실행된다.
    // 업데이트 함수 호출 순서 : Update() -> LateUpdate()
    // 플레이어 캐릭터와 카메라와 같이 서로 다른 오브젝트 있을 때 플레이어 캐릭터가 Update()를 이용해 움직이고
    // 카메라는 LateUpdate()이용해서 플레이어 위치 바탕으로 이동하는 식으로 쓸 수 있다.
    private void LateUpdate()
    {
        Debug.Log("LateUpdate 함수가 실행되었습니다.");
    }

    // FixedUpdate 함수 : 프레임의 영향을 받지 않고 일정한 간격으로 호출.
    // Edit -> Project Settings -> Time 옵션의 Fixed Timestep 변수로 조절 가능.
    // 기본 값 : 0.02로 0.02초에 1번 호출된다는 뜻 == 1초에 50번
    private void FixedUpdate()
    {
        Debug.Log("FixedUpdate 함수가 실행되었습니다.");
    }

    // OnDestroy 함수 : 게임 오브젝트가 파괴될 때 1회 호출
    // 씬이 변경되거나 게임이 종료될 때에도 오브젝트가 파괴되기 때문에 호출된다.
    private void OnDestroy()
    {
        Debug.Log("OnDestroy 함수가 실행되었습니다.");
    }

    // OnApplicationQuit 함수 : 게임이 종료될 때 1회 호출. 유니티 에디터에서는 플레이 모드를 중지할 때 호출된다.
    private void OnApplicationQuit()
    {
        Debug.Log("OnApplicationQuit 함수가 실행되었습니다.");
    }

    // OnDisable 함수 : 컴포넌트가 활성화 되었다가 비활성화 될 때 마다 1회 호출. (OnEnable과 반대)
    private void OnDisable()
    {
        Debug.Log("OnDisable 함수가 실행되었습니다.");
    }
}
