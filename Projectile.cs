using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] float bulletSpeed = 5f;
    [SerializeField] int damageNumber = 5;


    void Update()
    {
        transform.Translate(Vector2.right * bulletSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Enemy")
        {
            other.gameObject.GetComponent<HealthManager>().DealDamage(damageNumber);
            Destroy(gameObject);
        }
    }

}