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

    [SerializeField] private IntVariable _shouldBubblePop;
    [SerializeField] private Vector3Event _onBubblePop;

    [SerializeField] private Animator _animator;
 



    private void OnEnable()
    {
        _boundaryLeftX = transform.position.x - _swayAmount;
        _boundaryRightX = transform.position.x + _swayAmount;

        if(_shouldBubblePop.Value % 5 == 0)
        {
            StartCoroutine(WhenToPop());
        }

        _shouldBubblePop.ApplyChange(1);
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(0,_movementSpeedY * Time.deltaTime,0);
        MoveLeftAndRight();
        //CheckTimeScale();
    }

    IEnumerator WhenToPop()
    {
        int _timeWhenPop = Random.Range(15, 35);

        yield return new WaitForSeconds(_timeWhenPop);

        _animator.SetBool("BubblePop", true);
        _onBubblePop.Raise(transform.position);
        yield return new WaitForSeconds(0.5f);
        Destroy(gameObject);
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
    //public void CheckTimeScale()
    //{
    //    if(Time.timeScale == 0)
    //    {
    //        GetComponent<CircleCollider2D>().enabled = false;
    //    }
    //    else
    //    {
    //        GetComponent<CircleCollider2D>().enabled = true;
    //    }
    //}
 
}
