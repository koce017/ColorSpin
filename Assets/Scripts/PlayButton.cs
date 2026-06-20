using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayButton : MonoBehaviour
{
    public void PlayLevel(string level)
    {
        SceneManager.LoadScene(level);
    }
}
