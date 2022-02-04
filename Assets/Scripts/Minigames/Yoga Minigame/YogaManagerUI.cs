using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class YogaManagerUI : MonoBehaviour
{
    // set images same as ID
    // foreach int in list check switch case with ID value
    // draw all of them in a line

    [SerializeField] private List<GameObject> icons = new List<GameObject>();
    [SerializeField] private YogaManager manager;
    [SerializeField] private Sprite[] newSprite;
    
    [SerializeField] private List<int> _IDlist = new List<int>();
    private int ID = 0;
    private int i = 0;

    private void OnEnable()
    {
        _IDlist = new List<int>();
        DrawImages();
    }

    private void DrawImages()
    {
        manager.CopyList(_IDlist);
        Debug.Log(_IDlist.Count);
        
        foreach (var icon in icons)
        {
            //set ID and Image
            ID = _IDlist[i];
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

    private void RemoveCurrentPose()
    {
        _IDlist.RemoveAt(0);
        GameObject _toBeDestroyed = icons[0];
        icons.RemoveAt(0);
        Destroy(_toBeDestroyed);
    }
    

    #region HardCodedButtons

    // giga hard code for epic pro gamers
    public void ButtonOne()
    {
        manager._pressedID = 0;
        manager.LookForCorrectID();
        RemoveCurrentPose();
    }
    public void ButtonTwo()
    {
        manager._pressedID = 1;
        manager.LookForCorrectID();
        RemoveCurrentPose();

    }
    public void ButtonThree()
    {
        manager._pressedID = 2;
        manager.LookForCorrectID();
        RemoveCurrentPose();

    }
    public void ButtonFour()
    {
        manager._pressedID = 3;
        manager.LookForCorrectID();
        RemoveCurrentPose();

    }
    public void ButtonFive()
    {
        manager._pressedID = 4;
        manager.LookForCorrectID();
        RemoveCurrentPose();

    }
    
    #endregion
}