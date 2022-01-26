using UnityEngine;

public class Leaf : MonoBehaviour
{
    [SerializeField] private IntVariable _currentLeafAmount;
    [SerializeField] private GameObject _bonsaiTree;
    private Vector2 _startLeafPosition;
    private float _movementSpeedY = 1;
    private bool _isFalling = false;

    private void OnEnable()
    {
        _startLeafPosition = transform.position;
    }

    private int CutLeaf()
    {
        return _currentLeafAmount.ApplyChange(-1);
    }
    private void OnMouseDown()
    {
        if (!_isFalling)
        {
            CutLeaf();
            _bonsaiTree.GetComponent<BonsaiManager>().UpdateCurrentLeaf();
            _isFalling = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (_isFalling)
        {
            transform.position -= new Vector3(0, _movementSpeedY * Time.deltaTime, 0);
        }  
    }

    private void OnBecameInvisible()
    {
        _isFalling = false;
        transform.position = _startLeafPosition;
        gameObject.SetActive(false);
    }
}
