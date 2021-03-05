using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test_Collider : MonoBehaviour
{
    private BoxCollider col;

    // Start is called before the first frame update
    void Start()
    {
        col = GetComponent<BoxCollider>();
    }

    private void OnCollisionEnter(Collision collision) { 
    
    }

    private void OnCollisionExit(Collision collision) { 
    
    }

    private void OnCollisionStay(Collision collision) { 
    
    }
/*
    private void OnTriggerEnter(Collider other) { 
        
    }

    private void OnTriggerExit(Collider other) {
        other.transform.position = new Vector3(0, 2, 0);
    }

    private void OnTriggerStay(Collider other) {
        other.transform.position += new Vector3(0, 0, 0.01f);
    }*/
/*    // Update is called once per frame
    void Update()
    {
        *//*if (Input.GetKeyDown(KeyCode.W)) { //Down이 붙으면 w 아무리 눌러도 한번만 수행됨
            Debug.Log("col.bounds" + col.bounds);
            Debug.Log("col.bounds.extents" + col.bounds.extents);
            Debug.Log("col.bounds.extents.x" + col.bounds.extents.x);
            Debug.Log("col.size" + col.size);
            Debug.Log("col.center" + col.center);
        }*//*
        if (Input.GetMouseButtonDown(0)) { //0은 좌버튼 눌렀을 때
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitInfo;
            if (col.Raycast(ray, out hitInfo, 1000)) {
                this.transform.position = hitInfo.point;
            }
        }
    }*/
}
