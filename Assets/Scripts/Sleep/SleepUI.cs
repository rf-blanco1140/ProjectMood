using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SleepUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI textUI;
    [SerializeField] private RawImage fade;

    private Color _transparentColor;
    private Color _whiteColor;
    private Color _blackColor;
    
    private float _lerpTime;
    private float _colorLerpTime;
    private float _fadeLerpTime;
    
    public bool _startUI;
    public bool _continueUI;
    public bool _fadeToBlack;
    public bool _fadeFromBlack;
    
    private Vector3 _finalPosition = new Vector3(960, 540f, 0);
    private Vector3 _startPosition = new Vector3(960,3807,0);

    private RectTransform rectTransform;
    
    private void Awake()
    {
        _startPosition = new Vector3(960, 3807, 0);
        _finalPosition = new Vector3(960, 540f, 0);
        
        _transparentColor = new Color(0, 0, 0, 0);
        _whiteColor = new Color(1, 1, 1, 1);
        _blackColor = new Color(0, 0, 0, 1);
        textUI.color = _transparentColor;

        rectTransform = GetComponent<RectTransform>();
    }

    private void Update()
    {
        if (_fadeToBlack)
        {
            FadeToBlack();
        }
        else if (_fadeFromBlack)
        {
            FadeFromBlack();
        }
        
        if(_startUI)
        {
            TransitionToEndOfDaySummary();
            FadeFromBlack();
        }
        else if(_continueUI)
        {
            TransitionOutOfEndOfDaySummary();
            FadeToBlack();
        }
    }

    public void TransitionToEndOfDaySummary()
    {
        _startUI = true;
        _continueUI = false;
        
        _lerpTime = Time.deltaTime / 3;
        _colorLerpTime += Time.deltaTime / 10;

        rectTransform.localPosition = Vector3.Lerp(rectTransform.localPosition, _finalPosition, _lerpTime);
        textUI.color = Color.Lerp(_transparentColor, _whiteColor, _colorLerpTime);
    }
    
    public void TransitionOutOfEndOfDaySummary()
    {
        _continueUI = true;
        _startUI = false;
        
        _lerpTime = Time.deltaTime / 2;
        _colorLerpTime += Time.deltaTime / 2;

        //rectTransform.localPosition = Vector3.Lerp(rectTransform.localPosition, _startPosition, _lerpTime);
        rectTransform.localPosition = new Vector3(960, 4000, 0);
        textUI.color = Color.Lerp(_whiteColor, _transparentColor, _colorLerpTime);
    }

    public void SetStartPosition()
    {
        rectTransform.localPosition = _startPosition;
    }
    public void SetFinalPosition()
    {
        rectTransform.localPosition = _finalPosition;
    }
    
    public void FadeFromBlack()
    {
        _fadeToBlack = false;
        _fadeFromBlack = true;
        
        _fadeLerpTime += Time.deltaTime / 2f;
        fade.color = Color.Lerp(_blackColor, _transparentColor, _fadeLerpTime);
    }
    
    public void FadeToBlack()
    {
        _fadeToBlack = true;
        _fadeFromBlack = false;
        
        _fadeLerpTime += Time.deltaTime / 2f; 
        fade.color = Color.Lerp(_transparentColor, _blackColor, _fadeLerpTime);
    }

    public void ResetTimers()
    {
        _lerpTime = 0f;
        _colorLerpTime = 0f;
        _fadeLerpTime = 0f;
    }

    public void FadeText(GameObject gameObject)
    {
        _lerpTime = 0f;
        gameObject.GetComponent<Text>().color = Color.Lerp(_transparentColor, _whiteColor, _fadeLerpTime);
    }
}