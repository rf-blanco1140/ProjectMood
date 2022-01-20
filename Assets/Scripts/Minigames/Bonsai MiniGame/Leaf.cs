using UnityEngine;

public class Leaf : MonoBehaviour
{
    [SerializeField] private IntVariable _currentLeafAmount;
    [SerializeField] private GameObject _bonsaiTree;

    private int CutLeaf()
    {
        return _currentLeafAmount.ApplyChange(-1);
    }
    private void OnMouseDown()
    {
        CutLeaf();
        _bonsaiTree.GetComponent<BonsaiManager>().LeafCounter();
        gameObject.SetActive(false);
    }
}
