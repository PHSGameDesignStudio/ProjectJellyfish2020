using UnityEngine;
public class ObjectSpawner : MonoBehaviour
{
    public GameObject objectToInstantiate;
    public float spawnCooldown;
    float spawnTimer;
    public bool isParent;
    void Start()
    {
        spawnTimer = spawnCooldown;
    }
    void Update()
    {
        if (spawnTimer <= 0)
        {
            if (isParent) Instantiate(objectToInstantiate, transform);
            else Instantiate(objectToInstantiate, transform.position, Quaternion.identity);
            spawnTimer = spawnCooldown;
        }
        spawnTimer -= Time.deltaTime;
    }
}
