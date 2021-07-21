using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Defender : MonoBehaviour
{
    [SerializeField] int startCost = 100;

    public int GetStartCost() { return startCost; }

    public void AddStars(int amount)
    {
        FindObjectOfType<DisplayResource>().AddStars(amount);
    }

}
