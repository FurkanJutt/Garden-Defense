using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacker : MonoBehaviour
{
    [Header("Enemy Artributes")]
    [SerializeField] float health = 200f;
    [SerializeField] [Range(0f, 5f)] float walkSpeed = 1f;

    [Header("VFX / SFX")]
    [SerializeField] GameObject damageVfxPrefab, headPoint;

    GameObject currentTarget;
    LevelControler levelControler;

    private void Awake()
    {
        levelControler = FindObjectOfType<LevelControler>();
        if (levelControler != null)
            levelControler.AttackerSpawned();
    }

    private void OnDestroy()
    {
        if (levelControler != null)
            levelControler.AttackerKilled();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.left * walkSpeed * Time.deltaTime);
        UpdateAnimationState();
    }

    private void UpdateAnimationState()
    {
        if (!currentTarget)
        {
            GetComponent<Animator>().SetBool("IsAttacking", false);
        }
    }

    public void SetMovementSpeed(float speed)
    {
        walkSpeed = speed;
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        DamageDealer damageDealer = collider.gameObject.GetComponent<DamageDealer>();
        if (!damageDealer) return;
        ProcessHit(damageDealer);
    }

    private void ProcessHit(DamageDealer damageDealer)
    {
        GameObject damageVfx = Instantiate(damageVfxPrefab, headPoint.transform.position, Quaternion.identity);
        damageVfx.transform.Rotate(-11, 90, -90);
        health -= damageDealer.GetDamage();
        damageDealer.DestroyHit();
        if (health <= 0)
            DestroyEnemy();
        Destroy(damageVfx, 1f);
    }

    private void DestroyEnemy()
    {
        Destroy(gameObject);
    }

    public void Attack(GameObject target)
    {
        GetComponent<Animator>().SetBool("IsAttacking", true);
        currentTarget = target;
    }

    public void StrikeCurrentTarget(float damage)
    {
        if (!currentTarget) { return; }
        Defender defender = currentTarget.GetComponent<Defender>();
        if (defender)
            defender.TakeDamage(damage);

    }
}
