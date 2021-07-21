using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerLifeDisplay : MonoBehaviour
{
    [SerializeField] float baseLives = 3;
    [SerializeField] int damage = 1;
    float lifePoints = 100;
    Text display;

    public int LifePoints { get; }

    private void Start()
    {
        lifePoints = baseLives - PlayerPrefsController.GetDifficulty();
        display = GetComponent<Text>();
        UpdateDisplay();
        Debug.Log("My current difficulty " + PlayerPrefsController.GetDifficulty());
    }

    void UpdateDisplay()
    {
        display.text = lifePoints.ToString();
    }

    public void AddLife(int amount)
    {
        lifePoints += amount;
        UpdateDisplay();
    }

    public void SpendLife(int amount)
    {
        lifePoints -= amount;
        UpdateDisplay();
    }

}
