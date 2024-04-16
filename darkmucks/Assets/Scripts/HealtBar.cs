using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealtBar : MonoBehaviour
{
    Slider Healtbar;
    [SerializeField] private Gradient Bar;

    // Start is called before the first frame update
    void Awake()
    {
        Healtbar = GetComponent<Slider>();
    }

    private void Start()
    {
        Healtbar.maxValue = 100;
        Healtbar.minValue = 0;
        Healtbar.value = 100;
        Healtbar.wholeNumbers = true; //tam sayýlý iþlem ya gibi biþey
        Healtbar.fillRect.GetComponent<Image>().color = Bar.Evaluate(1f);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("e"))
        {
            if (Healtbar.value > 0) 
            {
                Debug.LogWarning("-5 hp");
                Healtbar.fillRect.GetComponent<Image>().color = Bar.Evaluate(Healtbar.normalizedValue);
                Healtbar.value -= 5;
            }
        }
        else if (Input.GetKeyDown("q"))
        {
            if (Healtbar.value < 100)
            {
                Debug.LogWarning("+5 hp");
                Healtbar.fillRect.GetComponent<Image>().color = Bar.Evaluate(Healtbar.normalizedValue);
                Healtbar.value += 5;
            }
        }       

        if (Healtbar.value <= 0)

        {
            Debug.LogWarning("GAME_OVER :D");
        }
    }
}
