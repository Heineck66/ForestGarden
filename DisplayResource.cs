using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayResource : MonoBehaviour
{
    [SerializeField] int resourcePoints = 150;
    Text display;

    public int ResourcePoints { get; }

    private void Start()
    {
        display = GetComponent<Text>();
        UpdateDisplay();
    }

    void UpdateDisplay()
    {
        display.text = resourcePoints.ToString();
    }

    public void AddStars(int amount)
    {
        resourcePoints += amount;
        UpdateDisplay();
    }

    public void SpendStarts(int amount)
    {
        resourcePoints -= amount;
        UpdateDisplay();
    }

    public bool HaveResourcesEnought(int amount)
    {
        return resourcePoints >= amount;
    }

}
