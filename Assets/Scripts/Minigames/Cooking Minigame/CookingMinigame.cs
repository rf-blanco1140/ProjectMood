using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MoreMountains.Feedbacks;

public class CookingMinigame : MonoBehaviour
{
    [SerializeField] private FloatVariable _appetite;
    [SerializeField] private VoidEvent _onWinGame;
    [SerializeField] private GameObject _CanvasBefore;
    [SerializeField] private GameObject _CanvasDuring;

    private AudioSource audioSource;
    [SerializeField] private AudioClip _fryingSFX;

    [SerializeField] private MMFeedbacks _fader;
    [SerializeField] private MMFeedbacks _winSFX;
    [SerializeField] private MMFeedbacks _failSFX;
    private GameObject _cookingIngredient;
    private int _ingredientState;
    private bool _isCooking;

    [SerializeField] private MoodSystem moodSystemRef;


    private void OnEnable()
    {
        _ingredientState = 0;
        _isCooking = false;
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
        audioSource.PlayOneShot(_fryingSFX);
        _isCooking = true;
        StartCoroutine(CookingTime());
        _CanvasDuring.SetActive(true);

    }

    IEnumerator CookingTime()
    {

        //time before cooked
        yield return new WaitForSeconds(8);
        _ingredientState++;
        _cookingIngredient.GetComponent<Ingredient>().NextSprite();

        //time before overcooked
        yield return new WaitForSeconds(3);
        _ingredientState++;
        _cookingIngredient.GetComponent<Ingredient>().NextSprite();

        //time before game ends
        yield return new WaitForSeconds(2);
        StopCooking();
    }

    public void StopCooking()
    {
        StopCoroutine(CookingTime());

        if (_ingredientState == 1)
        {
            _winSFX.PlayFeedbacks();
            Debug.Log("Best Win");
            _appetite.ApplyChange(20);
            _onWinGame.Raise();
        }
        else
        {
            _failSFX.PlayFeedbacks();
            Debug.Log("Too early or late");
        }
        AudioManager.instance.ReturnToDefault();
        audioSource.Stop();

        _fader.PlayFeedbacks();
        transform.parent.gameObject.SetActive(false);

        moodSystemRef.PlayIncreaseStatAnim(Stats.Appetite);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && _isCooking)
        {
            _fader.PlayFeedbacks();
            Delay();
            audioSource.Stop();
            AudioManager.instance.ReturnToDefault();
            StopCooking();
        }
    }
    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    private IEnumerator Delay()
    {
        
        yield return new WaitForSeconds(1);
        
    }
}
