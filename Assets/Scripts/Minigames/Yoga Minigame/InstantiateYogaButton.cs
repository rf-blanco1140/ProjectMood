using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class InstantiateYogaButton : MonoBehaviour
{
    [SerializeField] private GameObject button;
    [SerializeField] private YogaManagerUI managerUI;
    [SerializeField] private GameObject parent;
    private List<GameObject> gameObjectList = new List<GameObject>();
    private float currentValue = 18.3f;
    float j = 0f;
    
    public void RemoveDuplicateButtons(List<int> intList)
    {
        List<int> sortedList = new List<int>(0);
        
        foreach (var sorted in intList)
        {
            sortedList.Add(sorted);
        }
        sortedList.Sort();
        List<int> newList = sortedList.Distinct().ToList();

        InstantiateButtons(newList);
    }
    
    private void InstantiateButtons(List<int> intList)
    {
        foreach (var variable in intList)
        {
            GameObject newButton = Instantiate(button,new Vector3((currentValue += j),-0.8f,-4.25f),Quaternion.identity);
            j = 0.4f;

            newButton.transform.parent = parent.transform;
            
            newButton.GetComponent<YogaButton>().i = variable;
            managerUI.GetCurrentImage(variable, newButton);
            gameObjectList.Add(button);
        }
    }
}