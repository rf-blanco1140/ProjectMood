using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using MoreMountains.Feedbacks;
public class MinigameText : MonoBehaviour
{
    [SerializeField] private RectTransform _parent;
    [SerializeField] private Camera _camera;
    [SerializeField] private RectTransform _text;
    [SerializeField] private Canvas _canvas;
    [SerializeField] private MMFeedbacks _popSound;
    
    [SerializeField] List<string> _messages = new List<string>();


    public void ShowBubbleText(Vector3 BubblePosition)
    {
        int indexInList = Random.Range(0, _messages.Count - 1);
        _text.gameObject.GetComponent<TMPro.TextMeshProUGUI>().text = _messages[indexInList];
        //_popSound.PlayFeedbacks();
        Vector2 anchoredPos;

        RectTransformUtility.ScreenPointToLocalPointInRectangle(_parent, _camera.WorldToScreenPoint(BubblePosition),
            _canvas.renderMode == RenderMode.ScreenSpaceOverlay ? null : _camera, out anchoredPos);
        _text.anchoredPosition = anchoredPos;

    }
}
