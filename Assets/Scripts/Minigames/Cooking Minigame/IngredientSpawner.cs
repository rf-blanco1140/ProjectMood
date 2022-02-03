using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IngredientSpawner : MonoBehaviour
{
    [SerializeField] private GameObject _veganIngredient;
    [SerializeField] private GameObject _meatIngredient;

    [SerializeField] private GameObject _gameCanvas;

    public void SpawnVeganIngredient()
    {
        Instantiate(_veganIngredient, transform.position, transform.rotation);
        _gameCanvas.SetActive(false);
    }


    public void SpawnMeatIngredient()
    {
        Instantiate(_meatIngredient, transform.position, transform.rotation);
        _gameCanvas.SetActive(false);
    }

}
