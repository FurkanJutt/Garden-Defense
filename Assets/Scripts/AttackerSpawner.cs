using System.Collections;
using UnityEngine;

public class AttackerSpawner : MonoBehaviour
{
    [SerializeField] Attacker[] attackerPrefabs;
    [SerializeField] float minSpawnDelay = 1f;
    [SerializeField] float maxSpawnDelay = 5f;

    bool spawnLoop = true;

    // Start is called before the first frame update
    IEnumerator Start()
    {
        while (spawnLoop)
        {
            yield return new WaitForSeconds(UnityEngine.Random.Range(minSpawnDelay, maxSpawnDelay));
            SpawnAttackers();
        }
    }

    public void StopSpawn()
    {
        spawnLoop = false;
    }

    private void SpawnAttackers()
    {
        Attacker newAttacker = Instantiate(attackerPrefabs[Random.Range(0, attackerPrefabs.Length)], transform.position, transform.rotation) as Attacker;
        newAttacker.transform.parent = transform;
    }
}
