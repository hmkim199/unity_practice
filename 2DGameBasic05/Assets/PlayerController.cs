using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) {
            animator.SetTrigger("isDie");
            // animator.SetBool();
            // animator.SetFloat();
            // animator.SetInteger();
        }
    }

    // 애니메이션 재생 도중 함수 호출. public이어야 애니메이터에서 호출 가능
    public void OnDieEvent() {
        Debug.Log("End of Die Animation");
    }

}
