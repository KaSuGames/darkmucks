using UnityEngine;
using UnityEngine.UI;

public class Attack : MonoBehaviour
{
    Animator animator;
    public Slider slider;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        // Hareket animasyonlarýný kontrol et
        if (Input.GetKey("w"))
        {
            animator.SetBool("IsWalking", true);
        }
        else if (Input.GetKey("a"))
        {
            animator.SetBool("IsLeft", true);
        }
        else if (Input.GetKey("d"))
        {
            animator.SetBool("IsRight", true);
        }
        else if (Input.GetKey("s"))
        {
            animator.SetBool("IsBackWard", true);
        }

        else
        {
            animator.SetBool("IsWalking", false);
            animator.SetBool("IsBackWard", false);
            animator.SetBool("IsLeft", false);
            animator.SetBool("IsRight", false);
            animator.SetBool("Block", false);
        }

        if (Input.GetMouseButtonDown(0))
        {
             animator.SetTrigger("Slash"); 
        }
        else if (Input.GetMouseButtonDown(1))
        {
            animator.SetTrigger("Slash");
        }

        else if (Input.GetKey(KeyCode.LeftShift))
        {
            //animator.SetTrigger("Block");
            animator.SetBool("Block", true);
        }

        if (slider.value == 0)
        {
            animator.SetTrigger("die");
        }
    }
}
