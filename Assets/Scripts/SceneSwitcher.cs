using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
    private int _currentSceneIndex;
    private int _totalScenes;
    
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SwitchScene();
        }
    }

    private void Start()
    {
        DontDestroyOnLoad(gameObject);
        LoadScene(1);
    }

    private void Awake()
    {
        _totalScenes = SceneManager.sceneCountInBuildSettings;
    }

    private void SwitchScene()
    {
        int index = (_currentSceneIndex + 1) % _totalScenes;
        LoadScene(index > 0 ? index : 1);
    }

    private void LoadScene(int index)
    {
        _currentSceneIndex = index;
        SceneManager.LoadScene(index);
    }
}
