using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemainingStars : MonoBehaviour
{
    int remainingStars;

    //Start is called before the first frame update
    void Awake()
    {
        if (FindObjectsOfType<RemainingStars>().Length > 1)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    public void SetRemainingStars(int stars)
    {
        remainingStars = stars;
    }

    public int GetRemainingStars()
    {
        return remainingStars;
    }

}
