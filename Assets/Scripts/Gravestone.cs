using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gravestone : MonoBehaviour
{
    private void OnTriggerStay2D(Collider2D collider)
    {
        Attacker attacker = collider.GetComponent<Attacker>();
        Lizard lizard = collider.GetComponent<Lizard>();

        if (attacker && lizard)
        {
            GetComponent<Animator>().SetBool("IsBeingAttacked", true);
        }
    }
}
