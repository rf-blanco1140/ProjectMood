using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ingredient : MonoBehaviour
{
    [SerializeField] private Sprite _uncookedSprite;
    [SerializeField] private Sprite _cookedSprite;
    [SerializeField] private Sprite _overcookedSprite;

    private void OnEnable()
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = _uncookedSprite;
    }

    public void NextSprite()
    {
        if(gameObject.GetComponent<SpriteRenderer>().sprite == _uncookedSprite)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = _cookedSprite;
        }
        else if(gameObject.GetComponent<SpriteRenderer>().sprite == _cookedSprite)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = _overcookedSprite;
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
