using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SelectionButtons : MonoBehaviour
{
    [SerializeField] Defender defenderPrefab;

    SpriteRenderer buttonColor;
    Color prevColor;
    private void Start()
    {
        buttonColor = GetComponent<SpriteRenderer>();
        prevColor = buttonColor.color;
        LabelButtonCost();
    }

    private void LabelButtonCost()
    {
        TextMeshProUGUI costText = GetComponentInChildren<TextMeshProUGUI>();
        if (costText)
        {
            costText.text = defenderPrefab.GetStarCost().ToString();
        }
    }

    private void OnMouseEnter()
    {
        if (buttonColor.color == prevColor)
            buttonColor.color = Color.white;
    }

    private void OnMouseExit()
    {
        if (buttonColor.color == Color.white)
            buttonColor.color = prevColor;
    }

    private void OnMouseDown()
    {
        var buttons = FindObjectsOfType<SelectionButtons>();
        foreach (SelectionButtons button in buttons)
        {
            button.buttonColor.color = prevColor;
        }
        buttonColor.color = new Color32(242, 255, 0, 255);

        FindObjectOfType<DefenderSpawner>().SetSelectedDefender(defenderPrefab);
    }
}
