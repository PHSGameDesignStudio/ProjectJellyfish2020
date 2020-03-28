using UnityEngine;
public class MoveTowards : MonoBehaviour
{
    public Vector2 destination;
    public bool destroyOnDestination = false;
    public float speed;
    public bool useRandomX;
    public bool useRandomY;
    
    void Start()
    {
        var pos = transform.position;
        if (useRandomX)
        {
            var x = destination.x;
            pos.x = destination.x = Random.Range(-x, x);
            transform.position = pos;
        }
        if (useRandomY)
        {
            var y = destination.y;
            pos.y = destination.y = Random.Range(-y, y);
            transform.position = pos;
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, destination, speed * Time.deltaTime);
        if (transform.position == (Vector3)destination && destroyOnDestination)
        {
            Destroy(gameObject);
        }
    }

}