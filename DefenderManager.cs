using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenderManager : MonoBehaviour
{
    Defender defender = null;
    DisplayResource starDisplay;
    GameObject defenderParent;
    string DEFENDER_PARENT_NAME = "Defenders";

    private void Start()
    {
        SetDefenderParent();
        starDisplay = FindObjectOfType<DisplayResource>();
    }

    private void SetDefenderParent()
    {
        defenderParent = GameObject.Find(DEFENDER_PARENT_NAME);
        if (!defenderParent)
        {
            defenderParent = new GameObject(DEFENDER_PARENT_NAME);
        }
    }

    private void OnMouseDown()
    {
        AttemptToPlaceDefender();
    }

    public void SetSelectedDefender(Defender selectedDefender)
    {
        defender = selectedDefender;
    }

    private void AttemptToPlaceDefender()
    {
        if (defender == null) { Debug.Log("Defender not selected."); return; }
        int defenderCost = defender.GetStartCost();
        if (starDisplay.HaveResourcesEnought(defenderCost))
        {
            SpawnDefender(GetSquareClicked());
            starDisplay.SpendStarts(defenderCost);
        }
        else
        {
            Debug.Log("Insuficient Resource.");
        }

    }

    private Vector2 GetSquareClicked()
    {
        Vector2 clickPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        Vector2 worldPos = Camera.main.ScreenToWorldPoint(clickPos);
        Vector2 gridPos = SnapToGrid(worldPos);
        return gridPos;
    }

    private Vector2 SnapToGrid(Vector2 rawWorldPos)
    {
        int newX = Mathf.RoundToInt(rawWorldPos.x);
        int newY = Mathf.RoundToInt(rawWorldPos.y);
        return new Vector2(newX, newY);
    }

    private void SpawnDefender(Vector2 roundedWorldPos)
    {
        Defender newDefender = Instantiate(defender, roundedWorldPos, Quaternion.identity) as Defender;
        newDefender.transform.parent = defenderParent.transform;
    }
}
