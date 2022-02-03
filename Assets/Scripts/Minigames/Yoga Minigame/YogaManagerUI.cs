using System.Collections.Generic;
using UnityEngine;

public class YogaManagerUI : MonoBehaviour
{
    // set images same as ID
    // foreach int in list check switch case with ID value
    // draw all of them in a line

    [SerializeField] private GameObject[] icons;
    [SerializeField] private YogaManager manager;
    [SerializeField] private Sprite[] newSprite;
    
    private List<int> _IDlist = new List<int>();
    private int i;

    private void OnEnable()
    {
        DrawImages();
    }

    private void DrawImages()
    {
        manager.CopyList(_IDlist);
        Debug.Log($"ID list Count{_IDlist.Count} \n");
        foreach (var icon in icons)
        {
            //set ID and Image
            int ID = _IDlist[i];
            Debug.Log($"{ID} \n");
            GetCurrentImage(ID, icon);
            i++;
        }
    }
    
    private void GetCurrentImage(int ID, GameObject icon)
    {
        switch (ID)
        {
            case 0: 
                Debug.Log("image 1");
                icon.GetComponent<SpriteRenderer>().sprite = newSprite[ID];
                break;
            case 1: 
                Debug.Log("image 2");
                icon.GetComponent<SpriteRenderer>().sprite = newSprite[ID];
                break;
            case 2: 
                Debug.Log("image 3");
                icon.GetComponent<SpriteRenderer>().sprite = newSprite[ID];
                break;
            case 3: 
                Debug.Log("image 4");
                icon.GetComponent<SpriteRenderer>().sprite = newSprite[ID];
                break;
            case 4: 
                Debug.Log("image 5");
                icon.GetComponent<SpriteRenderer>().sprite = newSprite[ID];
                break;
        }
    }
    
    // giga hard code for epic pro gamers
    public void ButtonOne()
    {
        manager._pressedID = 0;
        manager.LookForCorrectID();
    }
    public void ButtonTwo()
    {
        manager._pressedID = 1;
        manager.LookForCorrectID();
    }
    public void ButtonThree()
    {
        manager._pressedID = 2;
        manager.LookForCorrectID();
    }
    public void ButtonFour()
    {
        manager._pressedID = 3;
        manager.LookForCorrectID();
    }
    public void ButtonFive()
    {
        manager._pressedID = 4;
        manager.LookForCorrectID();
    }
}