using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InhaleExhaleMinigame : MonoBehaviour
{
    [SerializeField] private GameObject _inhaleText;
    [SerializeField] private GameObject _exhaleText;
    [SerializeField] private GameObject _pressText;


    private Vector3 _inhaleScale;
    [SerializeField] private Vector3 _exhaleScale = new Vector3(10f, 10f, 10f);
    [SerializeField] private float _timePerBreath = 4;

    [SerializeField] private int _breathsToWin = 5;
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
            _isInhale = false;
            _readyToPress = false;
            _pressText.SetActive(false);
            StartCoroutine(Inhale(_exhaleScale));
        }
        else if (_readyToPress && !_isInhale)
        {
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
            //AudioManager.instance.ReturnToDefault();
            transform.parent.gameObject.SetActive(false);
        }
    }
}