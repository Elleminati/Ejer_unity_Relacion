using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    private Rigidbody2D Rplayer;
    private SpriteRenderer Santa;
    private bool flip = false;
    private float speed = 10.0f;
    private Vector2 target;
    private Vector2 position;
    private Camera cam;



    // Use this for initialization
    void Start()
    {
        Rplayer = GetComponent<Rigidbody2D>();
        Santa = GetComponent<SpriteRenderer>();

        target = new Vector2(0.0f, 0.0f);
        position = gameObject.transform.position;

        cam = Camera.main;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            Vector3 position = this.transform.position;
            position.x--;
            this.transform.position = position;
            flip = false;
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            Vector3 position = this.transform.position;
            position.x++;
            this.transform.position = position;
            flip = true;
        }

        float step = speed * Time.deltaTime;

        transform.position = Vector2.MoveTowards(transform.position, target, step);




        Santa.flipX = flip;
    }

    void OnGUI()
    {
        Event currentEvent = Event.current;
        Vector2 mousePos = new Vector2();
        Vector2 point = new Vector2();

        mousePos.x = currentEvent.mousePosition.x;
        mousePos.y = cam.pixelHeight - currentEvent.mousePosition.y;
        point = cam.ScreenToWorldPoint(new Vector3(mousePos.x, mousePos.y, 0.0f));

        if (Input.GetMouseButtonDown(0))
        {
            target = point;
        }
    }
}
