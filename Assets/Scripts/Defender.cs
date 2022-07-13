using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Defender : MonoBehaviour
{
    [SerializeField] float health = 200f;
    [SerializeField] int starCost = 30;

    [Header("VFX / SFX")]
    [SerializeField] GameObject damageVfxPrefab, headPoint;

    public void AddToStars(int amount)
    {
        FindObjectOfType<StarsDisplay>().AddToStars(amount);
    }
    
    public int GetStarCost()
    {
        return starCost;
    }

    //public void TakeDamage(Attacker attacker)
    //{
    //    DamageDealer damageDealer = attacker.gameObject.GetComponent<DamageDealer>();
    //    if (!damageDealer) return;
    //    ProcessHit(damageDealer);
    //}

    public void TakeDamage(float damage)
    {
        //GameObject damageVfx = Instantiate(damageVfxPrefab, transform.position, Quaternion.identity);
        //damageVfx.transform.Rotate(-11, 90, -90);
        health -= damage;
        if (health <= 0)
            DestroyDefender();
        //Destroy(damageVfx, 1f);
    }

    private void DestroyDefender()
    {
        Destroy(gameObject);
    }
}
