using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;

public class TEST : MonoBehaviour
{
    [SerializeField] private GameObject icon;
    [SerializeField] private Sprite[] newSprite;
    [SerializeField] private List<int> _IDlist = new List<int>(){1,2,3,4,5};

    private List<GameObject> gameObjects = new List<GameObject>();
    
    private int i = 0;
    private float increment = 0f;
    private float currentVectorX = 0f;
    
    private void OnEnable()
    {
        DrawImages();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            GameObject lol = gameObjects[0];
            gameObjects.RemoveAt(0);
            Destroy(lol);
            foreach (var game in gameObjects)
            {
                var transformPosition = game.transform.position;
                game.transform.position = new Vector3(transformPosition.x += 7f, 12,0);
            }
            SetScale(gameObjects[0]);
        }
    }

    private void DrawImages()
    {
        foreach (var idList in _IDlist)
        {
            GameObject iconObject = Instantiate(icon, new Vector3((currentVectorX -= increment),12,0), Quaternion.identity);
            // set icon under parent
            increment = 7;
            

            gameObjects.Add(iconObject);
            GetCurrentImage(idList, icon);
        }
        
        SetScale(gameObjects[0]);
    }

    private void SetScale(GameObject ugh)
    {
        for (int j = 0; j < gameObjects.Count; j++)
        {
            if (j == 0)
            {
                ugh.transform.localScale = new Vector3(2, 2, 2);
            }
            
            else return;
        }
    }
    
    private void GetCurrentImage(int ID, GameObject icon) // rename
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
            case 5: 
                Debug.Log("image 6");
                icon.GetComponent<SpriteRenderer>().sprite = newSprite[ID];
                break;
            case 6: 
                Debug.Log("image 7");
                icon.GetComponent<SpriteRenderer>().sprite = newSprite[ID];
                break;
            case 7: 
                Debug.Log("image 8");
                icon.GetComponent<SpriteRenderer>().sprite = newSprite[ID];
                break;
            case 8: 
                Debug.Log("image 9");
                icon.GetComponent<SpriteRenderer>().sprite = newSprite[ID];
                break;
            case 9: 
                Debug.Log("image 10");
                icon.GetComponent<SpriteRenderer>().sprite = newSprite[ID];
                break;
        }
    }
}