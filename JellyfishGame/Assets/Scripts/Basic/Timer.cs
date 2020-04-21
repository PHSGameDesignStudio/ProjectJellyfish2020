using UnityEngine;
public class Timer : MonoBehaviour
{
    public float time;
    // Update is called once per frame
    void Update()
    {
        if (time < 0) Destroy(gameObject);
        time -= Time.deltaTime;
    }
}
