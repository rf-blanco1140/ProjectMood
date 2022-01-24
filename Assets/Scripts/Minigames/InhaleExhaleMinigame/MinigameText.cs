using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinigameText : MonoBehaviour
{
    [SerializeField] private RectTransform _parent;
    [SerializeField] private Camera _camera;
    [SerializeField] private RectTransform _text;
    [SerializeField] private Canvas _canvas;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetMouseButtonDown(0))
        //{
        //    Vector2 anchoredPos;
        //    RectTransformUtility.ScreenPointToLocalPointInRectangle(_parent, Input.mousePosition, 
        //        _canvas.renderMode == RenderMode.ScreenSpaceOverlay ? null : _camera, out anchoredPos);
        //    _text.anchoredPosition = anchoredPos;

        //}   
    }

    public void ShowBubbleText(Vector2 anchoredPos)
    {
        RectTransformUtility.ScreenPointToLocalPointInRectangle(_parent, Input.mousePosition,
            _canvas.renderMode == RenderMode.ScreenSpaceOverlay ? null : _camera, out anchoredPos);
        _text.anchoredPosition = anchoredPos;

    }


}
