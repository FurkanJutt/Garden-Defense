using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingEye : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collider)
    {
        GameObject defenderObject = collider.gameObject;
        if (defenderObject.GetComponent<Gravestone>())
        {
            GetComponent<Animator>().SetBool("IsAttacking", false);
        }
        else if (defenderObject.GetComponent<Defender>())
        {
            GetComponent<Attacker>().Attack(defenderObject);
        }
    }
}
