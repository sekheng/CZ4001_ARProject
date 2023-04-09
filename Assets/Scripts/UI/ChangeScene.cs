using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    private string currentARScene = "";

    public void LoadScene(string sceneName)
    {
        if (!string.IsNullOrEmpty(currentARScene))
        {
            SceneManager.UnloadSceneAsync(currentARScene);
        }

        SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Additive);
        currentARScene = sceneName;
    }
}
