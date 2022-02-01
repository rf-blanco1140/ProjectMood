using UnityEngine;

public class WaterDrop : MonoBehaviour
{
    private float _timer = 4f;
    private void Update()
    {
        _timer -= Time.deltaTime;
        TimeBeforeDespawn();
    }

    private void TimeBeforeDespawn()
    {
        if (_timer <= 0)
        {
            Destroy(gameObject);
        }
    }
}