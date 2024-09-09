using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtBox : MonoBehaviour
{

    [SerializeField] Stats currentHealth;
    float hurtTimer = 2.0f;

    private void OnTriggerEnter(Collider other)
    {
        currentHealth.amount -= 5f;
    }

    private void OnTriggerStay(Collider other)
    {
        if (hurtTimer <= 0f)
        {
            currentHealth.amount -= 5f;
            hurtTimer = 2f;
        }

        else
        {
            hurtTimer -= 1f * Time.deltaTime;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        hurtTimer = 2f;
    }
}
