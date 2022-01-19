using UnityEngine;

public class Leaf : MonoBehaviour
{
    [SerializeField] private IntVariable _currentLeafAmount;

    private int CutLeaf()
    {
        return _currentLeafAmount.ApplyChange(-1);
    }
    private void OnMouseDown()
    {
        CutLeaf();
        gameObject.SetActive(false);
    }
}
