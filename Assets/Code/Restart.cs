using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour
{
    public string SceneName;

    public void StartButton()
    {
        SceneManager.LoadScene(SceneName);
    }
}
