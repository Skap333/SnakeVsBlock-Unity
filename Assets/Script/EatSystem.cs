
using TMPro;
using UnityEngine;

public class EatSystem : MonoBehaviour
{
    public int Value;
    public TextMeshPro HPText;
    private void Start()
    {
        HPText.text = Value.ToString();
    }
}
