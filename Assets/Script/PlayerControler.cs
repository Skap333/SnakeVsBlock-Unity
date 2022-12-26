using TMPro;
using UnityEngine;

public class PlayerControler : MonoBehaviour
{
    public float forward = 5;
    public float sens;
    private Camera maincam;
    public Rigidbody player;
    private Vector2 mousepos;
    public Transform WorkHead;
    private float sidewaysSpeed;
    private SnakeBalls snakeBalls;
    public int HP = 1;
    public int Length = 1;
    public int Value;
    public TextMeshPro PlayerHPText;
    public GameObject wincanvas;
    private GameObject Block;
    public GameObject losecanvas;
    private void Start()
    {
        maincam = Camera.main;
        snakeBalls = GetComponent<SnakeBalls>();
        HP += Value;
        for (int i = 0; i < Value; i++)
        {
            Length++;
            snakeBalls.AddBall();
        }
    }

    private void Update()
    {
        WorkHead.transform.position = player.position;
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
        PlayerHPText.text = HP.ToString();
    }

    private void FixedUpdate()
    {
        if (Mathf.Abs(sidewaysSpeed) > 4) sidewaysSpeed = 4 * Mathf.Sign(sidewaysSpeed);
        player.velocity = new Vector3(sidewaysSpeed * 5,0, forward);

        sidewaysSpeed = 0;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Food")
        {
            Value = collision.gameObject.GetComponent<EatSystem>().Value;
            HP += Value;
            Destroy(collision.gameObject);
            for (int i = 0; i < Value; i++)
            {
                Length++;
                snakeBalls.AddBall();
            }
        }
        if (collision.gameObject.tag == "Block")
        {
            Value = collision.gameObject.GetComponent<BoxDeath>().Value;
            Block = collision.gameObject.GetComponent<BoxDeath>().BlockWall;
            if (Value >= HP)
            {
                AudioSource Music = GetComponent<AudioSource>();
                Music.Stop();
                forward = 0;   
                losecanvas.SetActive(true);
            }
            else
            {
                HP-= Value;
                Destroy(Block);
                for (int i = 0; i < Value; i++)
                {
                    Length--;
                    snakeBalls.RemoveBall();
                }
            }
        }
        if (collision.gameObject.tag == "finish")
        {
            AudioSource Music = GetComponent<AudioSource>();
            Music.Stop();
            forward = 0;
            wincanvas.SetActive(true);
        }
    }
    
}
