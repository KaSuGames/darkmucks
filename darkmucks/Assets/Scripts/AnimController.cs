using UnityEngine;
using UnityEngine.UI;

public class Attack : MonoBehaviour
{
    Animator animator;
    public Slider slider;
    float previousSliderValue;

    void Start()
    {
        animator = GetComponent<Animator>();
        previousSliderValue = slider.value;
    }

    void Update()
    {
        // Hareket animasyonlar�n� kontrol et
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
        else if (Input.GetKey(KeyCode.LeftShift))
        {
            animator.SetBool("Block", true);
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
            animator.SetTrigger("Slash1");
        }

        // Slider'�n de�eri azald���nda
        if (slider.value < previousSliderValue)
        {
            // A animasyonunu �al��t�r
            animator.SetTrigger("impact");
        }

        previousSliderValue = slider.value;

        // E�er slider'�n de�eri 0 ise ve karakter hen�z �lmemi�se
        if (slider.value == 0)
        {
            // "Die" animasyonunu ba�lat
            animator.SetTrigger("die");
        }
    }
}
