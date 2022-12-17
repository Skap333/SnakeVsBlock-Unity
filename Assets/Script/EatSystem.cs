using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class EatSystem : MonoBehaviour
{
    public int Healpoint;
    public TextMeshPro HPText;
    private void Start()
    {
        HPText.text = Healpoint.ToString();
    }
}
