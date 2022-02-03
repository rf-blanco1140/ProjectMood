using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiddleLung : MonoBehaviour
{
    [SerializeField] private List<Sprite> _lungSprites;
    [SerializeField] private int _spriteIndex;

    private void OnEnable()
    {
        _spriteIndex = 0;
        gameObject.GetComponent<SpriteRenderer>().sprite = _lungSprites[_spriteIndex];
    }

    public void NextSprite()
    {
        _spriteIndex++;
        gameObject.GetComponent<SpriteRenderer>().sprite = _lungSprites[_spriteIndex];

    }

}
