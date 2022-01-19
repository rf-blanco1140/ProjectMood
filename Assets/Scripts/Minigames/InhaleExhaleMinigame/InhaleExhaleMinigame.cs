using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InhaleExhaleMinigame : MonoBehaviour
{
    [SerializeField] private GameObject inhaleText;
    [SerializeField] private GameObject exhaleText;

    private Vector3 _inhaleScale;
    [SerializeField] private Vector3 _exhaleScale = new Vector3(10f, 10f, 10f);
    [SerializeField] private float _timePerBreath = 4;

    [SerializeField] private int _breathsToWin = 5;
    private int _amountOfBreath = 0;

    private bool _readyToPress;
    private bool _isInhale;

    private void OnEnable()
    {
        _inhaleScale = transform.localScale;
        _readyToPress = true;
        _isInhale = true;
        exhaleText.transform.parent.gameObject.SetActive(true);
        inhaleText.SetActive(true);
    }

    private void OnMouseDown()
    {
        if (_readyToPress && _isInhale)
        {
            _isInhale = false;
            _readyToPress = false;
            StartCoroutine(Inhale(_exhaleScale));
        }
        else if (_readyToPress && !_isInhale)
        {
            _isInhale = true;
            _readyToPress = false;
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

        Debug.Log("Done");
        inhaleText.SetActive(false);
        _readyToPress = true;
        exhaleText.SetActive(true);
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


        Debug.Log("Done");
        _amountOfBreath += 1;
        CheckIfWin();
        exhaleText.SetActive(false);
        _readyToPress = true;
        inhaleText.SetActive(true);
    }

    public void CheckIfWin()
    {
        if (_amountOfBreath >= _breathsToWin)
        {
            Debug.Log("MinigameDone");
            exhaleText.transform.parent.gameObject.SetActive(false);
            transform.parent.gameObject.SetActive(false);
        }
    }
}
