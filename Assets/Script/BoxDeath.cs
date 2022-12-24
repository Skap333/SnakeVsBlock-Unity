using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BoxDeath : MonoBehaviour
{
    public int Value;
    public GameObject BlockWall;
    public TextMeshPro HPText;
   
    private void Update()
    {
        HPText.text = Value.ToString();
    }

}
