using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gravestone : MonoBehaviour
{

    private void OnTriggerStay(Collider attacker)
    {
        if (attacker.GetComponent<Attacker>())
        {
            //TODO to some annimation

        }

    }

}
