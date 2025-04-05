using UnityEngine;

public class PersonAnimation : MonoBehaviour
{
    private Animator animator;
    private CharacterController characterController;
    
    void Start()
    {
        animator = GetComponent<Animator>();
        characterController = GetComponent<CharacterController>();
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            animator.SetFloat("Speed", 1);
            if (Input.GetKeyDown(KeyCode.Space))
            {
                animator.SetTrigger("Jump");
            }
        }
        else
        {
            animator.SetFloat("Speed", 0);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            animator.SetTrigger("Jump");
        }
    }
}
