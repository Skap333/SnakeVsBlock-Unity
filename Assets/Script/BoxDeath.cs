using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BoxDeath : MonoBehaviour
{
    public int health;
    public GameObject GameObject;
    public TextMeshPro HPText;
    public PlayerControler player;

    private void OnCollisionEnter(Collision collision)
    {
        StartCoroutine(BlockKilling());
    }
    IEnumerator BlockKilling()
    {
        while (true)
        {
            health--;
            player.HP--;
            if (health == 0)
            {
                Destroy(GameObject);
            }
            yield return new WaitForSeconds(0.2f);
        }        
    }
    private void Update()
    {
        HPText.text = health.ToString();
    }

}
