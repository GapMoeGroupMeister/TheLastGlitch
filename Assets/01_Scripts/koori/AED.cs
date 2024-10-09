using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AED : MonoBehaviour
{

    private void Start()
    {
        Heal();
    }

    private void Heal()
    {
        GameManager.Instance.Player.HealthComponent.CurrentHealth = GameManager.Instance.Player.HealthComponent.maxHealth;
    }
}
