using UnityEngine;

public class SprayWash : MonoBehaviour
{
    [SerializeField] private GameObject water;
    [SerializeField] [Range(0,1)] private float waterSpeed;
    
    private float _timer;
    private void Update()
    {
        _timer -= Time.deltaTime;
        SprayWater();
    }

    private void SprayWater( )
    {
        if (_timer <= 0)
        {
            Instantiate(water, transform.position, Quaternion.identity).GetComponent<Rigidbody>()?.AddForce(Vector3.forward * 1000, ForceMode.Force);
            _timer = waterSpeed;
        }
    }
}