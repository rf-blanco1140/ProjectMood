using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class InstantiateYogaButton : MonoBehaviour
{
    [SerializeField] private GameObject button;
    [SerializeField] private YogaManagerUI managerUI;
    
    private List<GameObject> gameObjectList = new List<GameObject>();
    private int currentValue = 14;
    int j = 0;
    
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
            GameObject newButton = Instantiate(button,new Vector3((currentValue -= j),-5,0),Quaternion.identity);
            j = 7;
            
            newButton.GetComponent<YogaButton>().i = variable;
            managerUI.GetCurrentImage(variable, newButton);
            gameObjectList.Add(button);
        }
    }
}