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

        // Slider'ýn deðeri azaldýðýnda
        if (slider.value < previousSliderValue)
        {
            // A animasyonunu çalýþtýr
            animator.SetTrigger("impact");
        }

        previousSliderValue = slider.value;

        // Eðer slider'ýn deðeri 0 ise ve karakter henüz ölmemiþse
        if (slider.value == 0)
        {
            // "Die" animasyonunu baþlat
            animator.SetTrigger("die");
        }
    }
}
