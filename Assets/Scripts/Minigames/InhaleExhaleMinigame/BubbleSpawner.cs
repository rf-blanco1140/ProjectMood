using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleSpawner : MonoBehaviour
{
    [SerializeField] List<Vector3> _spawnPos = new List<Vector3>();
    [SerializeField] private GameObject _spawnObject;
    [SerializeField, Tooltip("In seconds.")] private float _timeBeforeFirstSpawn;


    private void OnEnable()
    {
        _spawnRoutine = StartCoroutine(SpawnObjects());
    }

    private void OnDisable()
    {
        
    }

    private Coroutine _spawnRoutine;

    private IEnumerator SpawnObjects()
    {
        while (true)
        {
            CreateObject();
            yield return new WaitForSeconds(_timeBeforeFirstSpawn);
        }

        void CreateObject()
        {
            int spawnPoint;
            spawnPoint = Random.Range(0, _spawnPos.Count);
            Instantiate(_spawnObject, transform.position + _spawnPos[spawnPoint], Quaternion.identity);
        }
    }

}
