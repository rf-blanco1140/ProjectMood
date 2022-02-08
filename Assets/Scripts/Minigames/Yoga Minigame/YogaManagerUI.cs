using System.Collections.Generic;
using UnityEngine;

public class YogaManagerUI : MonoBehaviour
{
    [SerializeField] private GameObject icon;
    [SerializeField] private Sprite[] newSprite;
    
    private List<GameObject> icons = new List<GameObject>(0);
    
    private float increment = 0f;
    private float currentVectorX = 24f;

    public void DrawImages(List<int> _IDList)
    {
        foreach (var idList in _IDList)
        {
            GameObject iconObject = Instantiate(icon, new Vector3((currentVectorX += increment),10,45), Quaternion.identity);
            increment = 7;

            icons.Add(iconObject);

            GetCurrentImage(idList, iconObject);
        }
        
        SetScale(icons[0]);
    }

    private void SetScale(GameObject ugh)
    {
        for (int j = 0; j < icons.Count; j++)
        {
            if (j == 0)
            {
                ugh.transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);
            }
            
            else return;
        }
    }
    
    public void GetCurrentImage(int ID, GameObject icon) // rename
    {
        switch (ID)
        {
            case 0: 
                icon.GetComponent<SpriteRenderer>().sprite = newSprite[ID];
                break;
            case 1: 
                icon.GetComponent<SpriteRenderer>().sprite = newSprite[ID];
                break;
            case 2: 
                icon.GetComponent<SpriteRenderer>().sprite = newSprite[ID];
                break;
            case 3: 
                icon.GetComponent<SpriteRenderer>().sprite = newSprite[ID];
                break;
            case 4: 
                icon.GetComponent<SpriteRenderer>().sprite = newSprite[ID];
                break;
            case 5: 
                icon.GetComponent<SpriteRenderer>().sprite = newSprite[ID];
                break;
            case 6: 
                icon.GetComponent<SpriteRenderer>().sprite = newSprite[ID];
                break;
            case 7: 
                icon.GetComponent<SpriteRenderer>().sprite = newSprite[ID];
                break;
            case 8: 
                icon.GetComponent<SpriteRenderer>().sprite = newSprite[ID];
                break;
            case 9: 
                icon.GetComponent<SpriteRenderer>().sprite = newSprite[ID];
                break;
        }
    }

    public void OnButtonPressed()
    {
        RemoveLastIcon();
        
        foreach (GameObject game in icons)
        {
            Vector3 transformPosition = game.transform.position;
            game.transform.position = new Vector3(transformPosition.x -= 7f, 10,45);
        }
        
        SetScale(icons[0]);
    }

    private void RemoveLastIcon()
    {
        GameObject iconToBeDeleted = icons[0];
        icons.RemoveAt(0);
        Destroy(iconToBeDeleted);
    }
}