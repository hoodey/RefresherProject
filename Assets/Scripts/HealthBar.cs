using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{

    [SerializeField] Image healthBar;
    [SerializeField] Stats max;
    [SerializeField] Stats current;

    // Update is called once per frame
    void Update()
    {
        healthBar.fillAmount = current.amount/max.amount;
    }
}
