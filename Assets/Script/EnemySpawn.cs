using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public GameObject enemyPrefab;
    public Transform Companion;
    public float spawnRadius = 15f;
    public float spawnInterval = 3f;

    void Start()
    {
        InvokeRepeating(nameof(SpawnEnemy), spawnInterval, spawnInterval);
    }

    void SpawnEnemy()
    {
        if (Companion == null) return;

        float angle = Random.Range(0f, 360f) * Mathf.Deg2Rad;
        Vector3 spawnPos = Companion.position + new Vector3(Mathf.Cos(angle), Mathf.Sin(angle)) * spawnRadius;

        Instantiate(enemyPrefab, spawnPos, Quaternion.identity);
    }
}
