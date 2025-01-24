using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileSpawner : MonoBehaviour
{
    public GameObject tilePrefab;
    public Transform spawnArea;

    public float spawnRateMin = 0.5f;
    public float spawnRateMax = 2f;

    private float timer = 0f;
    private float spawnRate;

    void Start()
    {
        spawnRate = Random.Range(spawnRateMin, spawnRateMax);
    }

    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= spawnRate)
        {
            SpawnTile();
            timer = 0f;
            spawnRate = Random.Range(spawnRateMin, spawnRateMax);
        }
    }

    void SpawnTile()
    {
        BoxCollider2D boxCollider = spawnArea.GetComponent<BoxCollider2D>();

        if (boxCollider != null)
        {
            Vector2 randomPos = new Vector2(
                Random.Range(boxCollider.bounds.min.x, boxCollider.bounds.max.x),
                Random.Range(boxCollider.bounds.min.y, boxCollider.bounds.max.y)
            );

            GameObject tile = Instantiate(tilePrefab);
            tile.transform.position = randomPos;

        }
        else
        {
            Debug.LogError("SpawnArea ต้องมี BoxCollider2D!");
        }
    }

    public void ResetSpawner()
    {
        timer = 0f;
        spawnRate = Random.Range(spawnRateMin, spawnRateMax);
    }
}

