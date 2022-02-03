using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MoreMountains.Feedbacks;

public class InhaleExhaleMinigame : MonoBehaviour
{
    [SerializeField] private GameObject _inhaleText;
    [SerializeField] private GameObject _exhaleText;
    [SerializeField] private GameObject _pressText;
    [SerializeField] private VoidEvent _OnWinGame;
    [SerializeField] private FloatVariable _mindVariable;
    [SerializeField] private MiddleLung _middleLung;


    private Vector3 _inhaleScale;
    [SerializeField] private Vector3 _exhaleScale = new Vector3(10f, 10f, 10f);
    [SerializeField] private float _timePerBreath = 4;

    [SerializeField] private int _breathsToWin = 5;
    [SerializeField] private MMFeedbacks _breathInSFX;
    [SerializeField] private MMFeedbacks _breathOutSFX;
    [SerializeField] private MMFeedbacks _finishedSFX;
    [SerializeField] private MMFeedbacks _fadeOut;

    private int _amountOfBreath;

    private bool _readyToPress;
    private bool _isInhale;

    private void OnEnable()
    {
        _amountOfBreath = 0;
        _inhaleScale = transform.localScale;
        _readyToPress = true;
        _isInhale = true;
        _inhaleText.SetActive(true);
        _pressText.SetActive(true);
    }

    private void OnMouseDown()
    {
        if (_readyToPress && _isInhale)
        {
            _breathInSFX.PlayFeedbacks();
            _isInhale = false;
            _readyToPress = false;
            _pressText.SetActive(false);
            StartCoroutine(Inhale(_exhaleScale));
        }
        else if (_readyToPress && !_isInhale)
        {
            _breathOutSFX.PlayFeedbacks();
            _isInhale = true;
            _readyToPress = false;
            _pressText.SetActive(false);
            StartCoroutine(Exhale(_inhaleScale));
        }
    }

    IEnumerator Inhale(Vector3 destinationScale)
    {
        Vector3 originalScale = transform.localScale;

        float currentTime = 0.0f;

        do
        {
            transform.localScale = Vector3.Lerp(originalScale, destinationScale, currentTime / _timePerBreath);
            currentTime += Time.deltaTime;
            yield return null;
        } while (currentTime <= _timePerBreath);

        _middleLung.NextSprite();

        _inhaleText.SetActive(false);
        _readyToPress = true;
        _exhaleText.SetActive(true);
        _pressText.SetActive(true);
    }

    IEnumerator Exhale(Vector3 destinationScale)
    {
        Vector3 originalScale = transform.localScale;

        float currentTime = 0.0f;

        do
        {
            transform.localScale = Vector3.Lerp(originalScale, destinationScale, currentTime / _timePerBreath);
            currentTime += Time.deltaTime;
            yield return null;
        } while (currentTime <= _timePerBreath);

        _middleLung.NextSprite();

        _amountOfBreath += 1;
        CheckIfWin();
        _exhaleText.SetActive(false);
        _readyToPress = true;
        _inhaleText.SetActive(true);
        _pressText.SetActive(true);
    }

    public void CheckIfWin()
    {
        if (_amountOfBreath >= _breathsToWin)
        {
            
            _finishedSFX.PlayFeedbacks();
            
           
            _mindVariable.ApplyChange(20);
            _OnWinGame.Raise();
            AudioManager.instance.ReturnToDefault();
            _fadeOut.PlayFeedbacks();
            transform.parent.gameObject.SetActive(false);
            
        }
    }
    private void Update()
    {
        CheckTimeScale();
    }
    public void CheckTimeScale()
    {
        if (Time.timeScale == 0)
        {
            GetComponent<CircleCollider2D>().enabled = false;
        }
        else
        {
            GetComponent<CircleCollider2D>().enabled = true;
        }
    }
}