using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CookingMinigame : MonoBehaviour
{
    [SerializeField] private FloatVariable _appetite;
    [SerializeField] private VoidEvent _onWinGame;
    [SerializeField] private GameObject _CanvasBefore;
    [SerializeField] private GameObject _CanvasDuring;
    private GameObject _cookingIngredient;
    private int _ingredientState;

    private void OnEnable()
    {
        _ingredientState = 0;
        _CanvasBefore.SetActive(true);
        _CanvasDuring.SetActive(false);

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Ingredient"))
        {
            StartCooking();
            _cookingIngredient = other.gameObject;
        }
    }

    public void StartCooking()
    {
        StartCoroutine(CookingTime());
        _CanvasDuring.SetActive(true);
    }

    IEnumerator CookingTime()
    {
        //Print the time of when the function is first called.
        Debug.Log("Started Coroutine at timestamp : " + Time.time);

        //yield on a new YieldInstruction that waits for 5 seconds.
        yield return new WaitForSeconds(8);
        _ingredientState++;
        _cookingIngredient.GetComponent<Ingredient>().NextSprite();
        Debug.Log("Almost there");

        //Testing
        yield return new WaitForSeconds(3);
        _ingredientState++;
        _cookingIngredient.GetComponent<Ingredient>().NextSprite();

        yield return new WaitForSeconds(2);

        //After we have waited 5 seconds print the time again.
        Debug.Log("Finished Coroutine at timestamp : " + Time.time);
        StopCooking();
    }

    public void StopCooking()
    {
        StopCoroutine(CookingTime());

        if (_ingredientState == 1)
        {
            Debug.Log("Best Win");
            _appetite.ApplyChange(20);
            _onWinGame.Raise();
        }
        else
        {
            Debug.Log("Too early or late");
        }

        transform.parent.gameObject.SetActive(false);

    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            StopCooking();
        }
    }
}
