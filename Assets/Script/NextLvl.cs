using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLvl : MonoBehaviour
{
    public string nextlvlnum;
    public void NextLVL()
    {
        SceneManager.LoadScene(nextlvlnum);
    }
}
