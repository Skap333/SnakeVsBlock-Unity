using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerControler : MonoBehaviour
{
    public float forward = 5;
    public float sens;

    private Camera maincam;
    public Rigidbody componentRigidbody;

    private Vector2 mousepos;
    private float sidewaysSpeed;

    private void Start()
    {
        maincam = Camera.main;
        componentRigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            mousepos = maincam.ScreenToViewportPoint(Input.mousePosition);
        }
        else if (Input.GetMouseButtonUp(0))
        {
            sidewaysSpeed = 0;
        }
        else if (Input.GetMouseButton(0))
        {
            Vector2 delta = (Vector2)maincam.ScreenToViewportPoint(Input.mousePosition) - mousepos;
            sidewaysSpeed += delta.x * sens;
            mousepos = maincam.ScreenToViewportPoint(Input.mousePosition);
        }
    }

    private void FixedUpdate()
    {
        if (Mathf.Abs(sidewaysSpeed) > 4) sidewaysSpeed = 4 * Mathf.Sign(sidewaysSpeed);
        componentRigidbody.velocity = new Vector3(sidewaysSpeed * 5,0, forward);

        sidewaysSpeed = 0;
    }
}
