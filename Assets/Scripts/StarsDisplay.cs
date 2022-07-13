using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StarsDisplay : MonoBehaviour
{
    int stars;
    TextMeshProUGUI starsText;
    RemainingStars remainingStars;

    // Start is called before the first frame update
    void Start()
    {
        starsText = GetComponent<TextMeshProUGUI>();
        remainingStars = FindObjectOfType<RemainingStars>();
        Debug.Log("StarsDisplay :" + remainingStars.GetRemainingStars());
        stars += remainingStars.GetRemainingStars();
        UpdateStars();
    }

    public int GetStars()
    {
        return stars;
    }

    public void UpdateStars()
    {
        if (GetType() != null)
        {
            starsText.text = stars.ToString();
        }
    }

    public void AddToStars(int amount)
    {
        stars += amount;
        UpdateStars();
    }

    public void SpendStars(int amount)
    {
        if (stars >= amount)
        {
            stars -= amount;
            UpdateStars();
        }
    }

    public void SetStartingStars(int stars)
    {
        this.stars = stars;
        //UpdateStars();
    }

    public bool HaveEnoughStars(int amount)
    {
        return stars >= amount;
    }
}
