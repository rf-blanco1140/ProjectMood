using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IngredientSpawner : MonoBehaviour
{
    [SerializeField] private GameObject _veganIngredient;
    //[SerializeField] private GameObject _meatIngredient;
    [SerializeField] private List<GameObject> _nonVeganIngredients;

    [SerializeField] private GameObject _gameCanvas;

    public void SpawnVeganIngredient()
    {
        Instantiate(_veganIngredient, transform.position, transform.rotation);
        _gameCanvas.SetActive(false);
    }


    public void SpawnNonVeganIngredient()
    {
        int randomIndex = Random.Range(0, _nonVeganIngredients.Count);
        Debug.Log(randomIndex);
        Instantiate(_nonVeganIngredients[randomIndex], transform.position, transform.rotation);
        _gameCanvas.SetActive(false);
    }

}
