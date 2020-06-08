using UnityEngine.SceneManagement;
using UnityEngine;

public class MenuSelect : MonoBehaviour
{
    private void Start()
    {
        if (Time.timeScale == 0)
        {
            Time.timeScale = 1;
        }
    }

    public void select(string LevelName)
    {
        SceneManager.LoadScene(LevelName, LoadSceneMode.Single);
    }
}
