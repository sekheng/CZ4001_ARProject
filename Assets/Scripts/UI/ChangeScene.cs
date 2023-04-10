using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    private string currentARScene = "";

    public LeftPanelScript leftPanelScript; // Add a reference to the LeftPanelScript

    private GameObject activeARSceneObject;

    private void Start()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    public void LoadScene(string sceneName)
    {
        // Hide the sliding UI panel
        leftPanelScript.HidePanel();

        if (!string.IsNullOrEmpty(currentARScene))
        {
            StartCoroutine(SwitchScene(currentARScene, sceneName));
        }
        else
        {
            SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Single);
            currentARScene = sceneName;
            CreateActiveARSceneObject(sceneName);
        }
    }

    private IEnumerator SwitchScene(string unloadScene, string loadScene)
    {
        // Unload the previous scene
        AsyncOperation unloadOperation = SceneManager.UnloadSceneAsync(unloadScene);
        while (!unloadOperation.isDone)
        {
            yield return null;
        }

        Destroy(activeARSceneObject);

        // Load the new scene
        AsyncOperation loadOperation = SceneManager.LoadSceneAsync(loadScene, LoadSceneMode.Single);
        while (!loadOperation.isDone)
        {
            yield return null;
        }

        currentARScene = loadScene;
        CreateActiveARSceneObject(loadScene);
    }

    private void CreateActiveARSceneObject(string sceneName)
    {
        activeARSceneObject = new GameObject("ActiveARScene");
        activeARSceneObject.AddComponent<ActiveARScene>().sceneName = sceneName;
        DontDestroyOnLoad(activeARSceneObject);
    }
}

public class ActiveARScene : MonoBehaviour
{
    public string sceneName;
}
