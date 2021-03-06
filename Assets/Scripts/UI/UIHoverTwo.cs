using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UIHoverTwo : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{

    Vector3 cachedScale;
    public float sizeX;
    public float sizeY;
    public float sizeZ;

   

    void Start()
    {

        cachedScale = transform.localScale;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        
       transform.localScale = new Vector3(sizeX, sizeY, sizeZ);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
       
        transform.localScale = cachedScale;
    }

    public void resetText()
    {
        transform.localScale = cachedScale;
 
    }

}