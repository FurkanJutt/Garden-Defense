using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mushroom : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collider)
    {
        GameObject defenderObject = collider.gameObject;
        if (defenderObject.GetComponent<Defender>())
        {
            GetComponent<Attacker>().Attack(defenderObject);
        }
    }
}
