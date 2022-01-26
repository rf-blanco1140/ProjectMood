using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGameManager : MonoBehaviour
{
    private Scene scene;

    private void Start()
    {
        
    }

    public void startGame()
    {
        StartCoroutine(WaitForStart());
        
    }
    IEnumerator WaitForStart()
    {
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene("Indoor Mainscene");
    }
}
