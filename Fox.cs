using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fox : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<Gravestone>())
        {
            GetComponent<Animator>().SetTrigger("jumpTrigger");
        }
        else if (other.GetComponent<Defender>())
        {
            GetComponent<Attacker>().EnterAttackMode(other.gameObject);
        }
    }
}
