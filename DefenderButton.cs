using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DefenderButton : MonoBehaviour
{
    [SerializeField] Defender defenderPrefab = null;
    bool active;
    Text costText;

    private void Start()
    {
        active = false;
        costText = GetComponentInChildren<Text>();
        costText.text = defenderPrefab.GetStartCost().ToString();
    }

    private void OnMouseDown()
    {
        var buttons = FindObjectsOfType<DefenderButton>();
        foreach (var button in buttons)
        {
            button.DisableDefenderButton();
        }

        EnableDefenderButton();

    }

    private void EnableDefenderButton()
    {
        FindObjectOfType<DefenderManager>().SetSelectedDefender(defenderPrefab);
        gameObject.GetComponent<SpriteRenderer>().color = Color.white;
        active = true;
    }

    public void DisableDefenderButton()
    {
        gameObject.GetComponent<SpriteRenderer>().color = new Color32(48, 48, 48, 255);
        active = false;
    }

}
