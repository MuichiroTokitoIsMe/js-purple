using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Ghost : Movement
{
    public GameObject body;
    public GameObject eyes;
    public GameObject blue;
    public GameObject white;
    public bool atHome;
    public float homeDuration;
    private bool frightened;

    private void Awake()
    {
        body.SetActive(true);
        eyes.SetActive(true);
        blue.SetActive(false);
        white.SetActive(false);
        frightened = false;
        Invoke("Leavehome", homeDuration);
    }

    protected override void ChildUpdate()
    {

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (atHome && collision.gameObject.layer == LayerMask.NameToLayer("Obstacle"))
        {
            Setdirection(-direction);
        }   

        if (collision.gameObject.CompareTag("Pacman"))
        {
            if (frightened)
            {
                transform.position = new Vector3(0, -0.5f, -1);
                body.SetActive(false);
                eyes.SetActive(true);
                blue.SetActive(false);
                white.SetActive(false);
                atHome = true;
                CancelInvoke();
                Invoke("Leavehome", 4f);
            }
            else
            {
                Destroy(collision.gameObject);
                Destroy(collision.gameObject);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Node node = collision.GetComponent<Node>();

        if (node != null)
        {
            int index = Random.Range(0, node.availableDirections.Count);

            Setdirection(node.availableDirections[index]);
            
            if (node.availableDirections[index] == -direction)
            {
                index += 1;

                if (index == node.availableDirections.Count)
                {
                    index = 0;
                }
            }

            Setdirection(node.availableDirections[index]);
        }
    }

    private void Leavehome ()
    {
        transform.position = new Vector3(0, 2.5f, -1f);
        direction = new Vector2(-1, 0);
        atHome = false;
        frightened = false;
        body.SetActive(true);
        eyes.SetActive(true);
        blue.SetActive(false);
        white.SetActive(false);
    }

    public void Frighten()
    {
        if (!atHome)
        {
            frightened = true;
            body.SetActive(false);
            eyes.SetActive(false);
            blue.SetActive(true);
            white.SetActive(false);
            Invoke("Flash", 4f);
        }
    }

    private void Flash ()
    {
        body.SetActive(false);
        eyes.SetActive(false);
        blue.SetActive(false);
        white.SetActive(true);
        Invoke("Reset", 4f);
    }

    private void Reset()
    {
        frightened = true;
        body.SetActive(true);
        eyes.SetActive(true);
        blue.SetActive(false);
        white.SetActive(false);
    }

    int joc = 1;
    float jocs = 5f;
    bool isCool = true;
    string text = "hi";
    
    
}

   
