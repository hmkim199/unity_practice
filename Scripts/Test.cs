using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
/*    [SerializeField]
    private GameObject go_camera;
    Vector3 rotation;*/
    void Start() {
/*        rotation = this.transform.eulerAngles;
*/    }

     //Update is called once per frame
    void Update()
    {
        /*rotation = rotation + new Vector3(90, 0, 0) * Time.deltaTime;
        if (Input.GetKey(KeyCode.W)) {
            this.transform.position = this.transform.position + new Vector3(0, 0, 1) * Time.deltaTime; //Time.deltaTime은 60분의 1정도 => 1초에 1씩이동
            this.transform.Translate(new Vector3(0, 0, 1) * Time.deltaTime); // 위 명령과 같은 역할.
            this.transform.eulerAngles = transform.eulerAngles + new Vector3(90, 0, 0) * Time.deltaTime; //=>이렇게 하면 90도정도부터 더 이상 회전하지 못하는 문제 발생. 유니티는 내부적으로 쿼터니언으로 바꾸는데 그래서 오일러앵글 값이 이상하게 보일 수 있음.
            this.transform.eulerAngles = rotation;
            Debug.Log(transform.eulerAngles);
            this.transform.Rotate(new Vector3(90, 0, 0) * Time.deltaTime);
            this.transform.rotation = Quaternion.Euler(rotation);
            this.transform.localScale = this.transform.localScale + new Vector3(2, 2, 2) * Time.deltaTime; // 1초에 2배씩 커지도록
            moveSpeed * this.transform.forward * Time.deltaTime// forward는 정규화 벡터(방향만을 알려주는 벡터: new Vector3(0, 0, 1)임)
            this.transform.up //=> new Vector(0, 1, 0)임. .right는 new Vector(1, 0, 0)
            this.transform.LookAt(go_camera.transform.position);

        }
        transform.RotateAround(go_camera.transform.position, Vector3.up, 100 * Time.deltaTime);*/

    }
}
