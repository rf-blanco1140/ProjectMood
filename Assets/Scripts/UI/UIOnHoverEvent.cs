using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UIOnHoverEvent : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{

    Vector3 cachedScale;
   // public float sizeX;
   // public float sizeY;
    //public float sizeZ;

    public Text m_Text;
    public int orgTextSize;
    public int bigTextSize;

    void Start()
    {

        cachedScale = transform.localScale;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        m_Text.fontSize = bigTextSize;
        //transform.localScale = new Vector3(sizeX, sizeY, sizeZ);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        m_Text.fontSize = orgTextSize;
        //transform.localScale = cachedScale;
    }

 public void resetText()
    {
        //transform.localScale = cachedScale;
        m_Text.fontSize = orgTextSize;
    }
   
}