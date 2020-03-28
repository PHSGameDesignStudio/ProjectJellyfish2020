using UnityEngine;
public class ObjectSpawner : MonoBehaviour
{
    public GameObject objectToInstantiate;
    public float spawnCooldown;
    float spawnTimer;
    void Start()
    {
        spawnTimer = spawnCooldown;
    }
    void Update()
    {
        if (spawnTimer <= 0)
        {
            Instantiate(objectToInstantiate);
            spawnTimer = spawnCooldown;
        }
        spawnTimer -= Time.deltaTime;
    }
}
