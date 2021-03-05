using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test_Rigidbody : MonoBehaviour
{
    
    private Rigidbody myRigid;
    private Vector3 rotation;

    // Start is called before the first frame update
    void Start()
    {
        myRigid = GetComponent<Rigidbody>();
/*        rotation = this.transform.eulerAngles;
*/    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W)) {
            /*            myRigid.velocity = Vector3.forward;
            */
            /*            myRigid.angularVelocity = -Vector3.right;
            */
            /*            myRigid.maxAngularVelocity = 1000;
                        myRigid.angularVelocity = Vector3.right * 100;*/
            /*            myRigid.MovePosition(transform.forward * Time.deltaTime); //관성 등 물리효과 적용안됨. 강제로 이동
            */
            /*            rotation += new Vector3(90, 0, 0) * Time.deltaTime;
            */            /*            myRigid.MoveRotation(Quaternion.Euler(rotation)); //관성 등 물리효과 적용안됨. 강제로 회전
                        */
            /*            myRigid.AddForce(Vector3.forward); //관성 등 물리효과 적용되는 이동.
            */
            /*            myRigid.AddTorque(Vector3.up); // 관성 등 물리효과 적용되는 회전.
            */
            myRigid.AddExplosionForce(10, this.transform.right, 10); // 폭발 같은 것 구현 때 유용.
        }
    }
}
