using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatFloor : MonoBehaviour
{
    public float speed;
    private Vector3 startPos;
    private float repeatWidth;
    private PlayerController playerController;

    // Start is called before the first frame update
    void Start()
    {
        playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();

        startPos = transform.position;
        repeatWidth = GetComponent<BoxCollider>().size.x * 2;
    }

    // Update is called once per frame
    void Update()
    { if (playerController.gameOver != true)
        {
            transform.Translate(Vector3.left * Time.deltaTime * speed);

            if (transform.position.x < (startPos.x - repeatWidth))
            {
                transform.position = startPos;
            }
        }
    }
}
