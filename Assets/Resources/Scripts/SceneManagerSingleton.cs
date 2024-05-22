using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagerSingleton : MonoBehaviour
{
    private static SceneManagerSingleton instance;

    public static SceneManagerSingleton Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<SceneManagerSingleton>();
                if (instance == null)
                {
                    GameObject obj = new GameObject();
                    obj.name = typeof(SceneManagerSingleton).Name;
                    instance = obj.AddComponent<SceneManagerSingleton>();
                    DontDestroyOnLoad(obj); // Ensures the object persists across scene changes
                }
            }
            return instance;
        }
    }

    // Your scene management methods can go here
    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
