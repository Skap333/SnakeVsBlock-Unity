
using UnityEngine;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour
{
    public string lvlnum;
    public void ReloadScene()
    {
        SceneManager.LoadScene(lvlnum);
    }
}
