using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lyzard : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<Defender>())
        {
            GetComponent<Attacker>().EnterAttackMode(other.gameObject);
        }
    }
}
