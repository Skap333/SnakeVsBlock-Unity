using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Game : MonoBehaviour
{
    public PlayerControler Playerstate;
    public GameObject loseCanvas;
   
    private void Update()
    {
        if (Playerstate.HP == 0)
        {
            Playerstate.forward = 0;
            loseCanvas.SetActive(true);
        }
    }
}
