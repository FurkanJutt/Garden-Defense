using UnityEngine;

public class DefenderShoot : MonoBehaviour
{
    [SerializeField] GameObject projectilePrefab;
    GameObject defender;

    AttackerSpawner myLaneSpawner;
    Animator animator;

    void Start()
    {
        defender = this.gameObject;
        SetLaneSpawners();
        animator = GetComponent<Animator>();
    }

    private void SetLaneSpawners()
    {
        AttackerSpawner[] spawners = FindObjectsOfType<AttackerSpawner>();

        foreach (AttackerSpawner spawner in spawners)
        {
            bool isCloseEnough = Mathf.Abs(spawner.transform.position.y - this.transform.position.y) <= Mathf.Epsilon;
            float test = Mathf.Abs(spawner.transform.position.y - this.transform.position.y);
            if (isCloseEnough)
                myLaneSpawner = spawner;
        }
    }

    private bool IsAttackerInLane()
    {
        if (myLaneSpawner.transform.childCount <= 0)
            return false;
        else
            return true;
    }

    public void Shoot()
    {
        GameObject shot = Instantiate(projectilePrefab, transform.position, Quaternion.identity);
        shot.transform.parent = defender.transform;
    }

    private void Update()
    {
        if (IsAttackerInLane())
        {
            animator.SetBool("IsAttacking", true);
        }
        else
        {
            animator.SetBool("IsAttacking", false);
        }
    }
}
