using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Creates and uses scene controlling menues.
/// </summary>
public class MenuLogic : MonoBehaviour
{
    // [SerializeField] string gameSceneName;
    
    public void OpenOptionsMenu ()
    {
        Debug.Log("Options menu not implemented");

    }

    public void ChangeScene (string sceneName)
    {
        SceneManager.LoadScene(sceneName);

    }

    public void Exit ()
    {
        Application.Quit();

    }
}
