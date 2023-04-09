using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    private string currentScene;

    public void LoadScene(string sceneName)
    {
        if (!string.IsNullOrEmpty(currentScene))
        {
            SceneManager.UnloadSceneAsync(currentScene);
        }

        SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Additive);
        currentScene = sceneName;
    }
}
