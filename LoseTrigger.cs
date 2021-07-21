using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseTrigger : MonoBehaviour
{
    PlayerLifeDisplay display;

    private void Start()
    {
        display = FindObjectOfType<PlayerLifeDisplay>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        DealDamage(other);
    }

    private void DealDamage(Collider2D other)
    {
        if (other.GetComponent<Attacker>())
        {
            var damage = other.GetComponent<Attacker>().GetDamage();
            display.SpendLife(damage);
            Destroy(other.gameObject);
            if (display.LifePoints <= 0)
            {
                EndGame();
            }
        }
    }

    private void EndGame()
    {
        FindObjectOfType<SceneLoader>().RestartGame();
    }
}
