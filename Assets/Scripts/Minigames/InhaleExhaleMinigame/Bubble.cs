using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bubble : MonoBehaviour
{
    [SerializeField] private float _movementSpeedY = 0.01f;
    [SerializeField] private float _movementSpeedX = 0.05f;
    [SerializeField] private float _boundaryRightX;
    [SerializeField] private float _boundaryLeftX;
    [SerializeField] private float _swayAmount = 1f;
    [SerializeField] private bool _GoRight = true;

    [SerializeField] private Vector3Event _onBubblePop;

    private void OnEnable()
    {
        _boundaryLeftX = transform.position.x - _swayAmount;
        _boundaryRightX = transform.position.x + _swayAmount;
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    private void OnMouseDown()
    {
        _onBubblePop.Raise(transform.position);
        Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(0,_movementSpeedY * Time.deltaTime,0);
        MoveLeftAndRight();
    }

    void MoveLeftAndRight()
    {
        if (_GoRight)
        {
            if (transform.position.x <= _boundaryRightX)
            {
                transform.position += new Vector3(_movementSpeedX * Time.deltaTime, 0f, 0f); ;
            }

            else
            {
                _GoRight = false;
            }
        }
        else
        {
            if (transform.position.x >= _boundaryLeftX)
            {
                transform.position += new Vector3(-_movementSpeedX * Time.deltaTime, 0f, 0f); ;
            }

            else
            {
                _GoRight = true;
            }

        }

    }
}
