using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fox : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collider)
    {
        GameObject defenderObject = collider.gameObject;
        if (defenderObject.GetComponent<Gravestone>())
        {
            GetComponent<Animator>().SetTrigger("JumpTrigger");
        }
        else if (defenderObject.GetComponent<Defender>())
        {
            GetComponent<Attacker>().Attack(defenderObject);
        }
    }
}
