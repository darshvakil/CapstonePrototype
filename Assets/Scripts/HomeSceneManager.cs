using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HomeSceneManager : MonoBehaviour
{
    public Button aboutButton; // Assign in Inspector
    public Button settingsButton;
    public Button quitButton;

    void Start()
    {
        if (aboutButton != null)
            aboutButton.onClick.AddListener(GoToAboutUs);
        if (settingsButton != null)
            settingsButton.onClick.AddListener(GoToSettings);
        if (quitButton != null)
            quitButton.onClick.AddListener(QuitGame);
    }

    public void StartGame()
    {
        SceneManager.LoadScene("SampleScene"); // Replace "GameScene" with your actual game scene name
    }
    

    public void GoToAboutUs()
    {
        Debug.Log("Loading AboutScene...");
        SceneManager.LoadScene("AboutScene");
    }

    public void GoToSettings()
    {
        PlayerPrefs.SetInt("FromGame", 0); // Ensure it's set to 0 when coming from home
        SceneManager.LoadScene("SettingScene");
    }

    public void QuitGame()
    {
        Debug.Log("Quitting Game...");
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
            Application.Quit();
#endif
    }
}
