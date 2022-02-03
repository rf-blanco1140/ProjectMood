using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CookingMinigame : MonoBehaviour
{
    [SerializeField] private FloatVariable _appetite;
    [SerializeField] private VoidEvent _onWinGame;
    [SerializeField] private Canvas _gameCanvas;
    private GameObject _cookingIngredient;

    private void OnEnable()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Ingredient"))
        {
            StartCooking();
        }
    }

    public void StartCooking()
    {
        StartCoroutine(CookingTime());
    }

    IEnumerator CookingTime()
    {
        //Print the time of when the function is first called.
        Debug.Log("Started Coroutine at timestamp : " + Time.time);

        //yield on a new YieldInstruction that waits for 5 seconds.
        yield return new WaitForSeconds(5);

        //After we have waited 5 seconds print the time again.
        Debug.Log("Finished Coroutine at timestamp : " + Time.time);
        StopCooking();
    }

    public void StopCooking()
    {
        StopCoroutine(CookingTime());
        Debug.Log("Win");
        _appetite.ApplyChange(20);
        _onWinGame.Raise();
        transform.parent.gameObject.SetActive(false);

    }
}
