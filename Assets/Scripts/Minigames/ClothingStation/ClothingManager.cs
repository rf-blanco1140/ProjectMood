using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClothingManager : MonoBehaviour
{
    
    [SerializeField] private BoolVariable _canWalk;
    // Start is called before the first frame update
  
    private void OnEnable()
    {
        Debug.Log("Change clothes");
        _canWalk.boolValue = false;
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnDisable()
    {
        AudioManager.instance.ReturnToDefault();
        Debug.Log("exit clothes");
        _canWalk.boolValue = true;
    }
}
