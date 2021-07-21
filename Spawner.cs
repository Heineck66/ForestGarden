using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] float timeToNextSpawnMin = 2f;
    [SerializeField] float timeToNextSpawnMax = 5f;
    [SerializeField] Attacker[] attacksArray = null;
    bool spawn = true;

    IEnumerator Start()
    {
        while (spawn)
        {
            yield return new WaitForSeconds(Random.Range(timeToNextSpawnMin, timeToNextSpawnMax));
            SpawnEnemy();
        }
    }

    public void StopSpawning()
    {
        spawn = false;
    }

    private void SpawnEnemy()
    {
        Attacker nextSpawn = attacksArray[Random.Range(0, attacksArray.Length)];
        Spawn(nextSpawn);
    }

    private void Spawn(Attacker attacker)
    {
        Attacker newAttacker = Instantiate(attacker, transform.position, Quaternion.identity) as Attacker;
        newAttacker.transform.SetParent(this.transform);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
