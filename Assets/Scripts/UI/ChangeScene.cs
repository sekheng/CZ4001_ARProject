using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    private string currentARScene = "";
    
    public LeftPanelScript leftPanelScript; // Add a reference to the LeftPanelScript

    public void LoadScene(string sceneName)
    {
        // Hide the sliding UI panel
        leftPanelScript.HidePanel();

        if (!string.IsNullOrEmpty(currentARScene))
        {
            SceneManager.UnloadSceneAsync(currentARScene);
        }

        SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Additive);
        currentARScene = sceneName;
    }
}
