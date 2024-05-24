using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawn : MonoBehaviour
{
   public int numberToSpawn; // Controls how many objects to spawn
    public List<GameObject> spawnPool; // List with prefabs that can spawn
    public GameObject quad; // GameObject where the prefabs should spawn
    public float frequency; // How often should they spawn
    float lastSpawnedTime; // Time which keeps track of last time spawned

    void Update()
    {
        // If time in Update method is bigger than lastSpawnedTime + frequency, run spawnObjects() and reset lastSpawnedTime
        if (Time.time > lastSpawnedTime + frequency)
        {
            spawnObjects();
            lastSpawnedTime = Time.time;
        }
    }

    public void spawnObjects()
    {
        // Check if quad is null or destroyed
        if (quad == null)
        {
            Debug.LogError("Quad GameObject is null or destroyed!");
            return;
        }

        // Sets the mesh collider class called "c" to the gameobject quad. It should be a mesh collider
        MeshCollider c = quad.GetComponent<MeshCollider>();

        // Check if mesh collider is null
        if (c == null)
        {
            Debug.LogError("Quad does not have a MeshCollider component!");
            return;
        }

        // Float points to store the random screen coordinates
        float screenX, screenY;

        // Vector2 which will hold the final spawn position
        Vector2 pos;

        // for loop iterates numberToSpawn
        for (int i = 0; i < numberToSpawn; i++)
        {
            // Check if spawnPool is empty
            if (spawnPool.Count == 0)
            {
                Debug.LogError("Spawn pool is empty!");
                return;
            }

            // Makes a random index within the range of 0 to spawnPool.Count
            int randomTile = Random.Range(0, spawnPool.Count);

            // Gets a GameObject from the spawnPool and stores it in toSpawn
            GameObject toSpawn = spawnPool[randomTile];

            // Check if toSpawn is null or destroyed
            if (toSpawn == null)
            {
                Debug.LogWarning("Object to spawn is null or destroyed! Skipping this spawn.");
                continue; // Skip this iteration and continue with the next one
            }

            // Gets a random coordinate from c min x to c max x
            screenX = Random.Range(c.bounds.min.x, c.bounds.max.x);
            // Gets a random coordinate from c min y to c max y
            screenY = Random.Range(c.bounds.min.y, c.bounds.max.y);
            // Creates a Vector2 position from the randomly generated x and y coordinates
            pos = new Vector2(screenX, screenY);

            // Instantiates a copy of the selected object at the Vector2 position
            Instantiate(toSpawn, pos, toSpawn.transform.rotation);
        }
    }
}
