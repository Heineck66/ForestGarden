using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : MonoBehaviour
{
    [SerializeField] int health = 10;
    [SerializeField] GameObject DeathVFX = null;

    public void DealDamage(int damageNumber)
    {
        health -= damageNumber;
        if (health <= 0)
        {
            TriggerDeathVFX();
            Destroy(gameObject);
        }
    }

    private void TriggerDeathVFX()
    {
        if (!DeathVFX) { return; }
        GameObject DeathVFXObject = Instantiate(DeathVFX, transform.position, transform.rotation);
        Destroy(DeathVFXObject, 1f);
    }
}
