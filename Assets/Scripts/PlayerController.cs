using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerController : MonoBehaviour
{

    public bool start = false;
    public float score;
    public float moveSpeed;
    public float lastMouseX;
    public TextMeshProUGUI scoreBoard;
    Animator playerAnimator;

    void Start()
    {
        playerAnimator = GetComponent<Animator>();
    }

    void Update()
    {

        if (Input.GetMouseButton(0))
        {
            start = true;
        }
        if (start)
        {
            playerAnimator.SetFloat("Blend", moveSpeed, 0.3f, Time.deltaTime);
            transform.Translate(0, 0, moveSpeed * Time.deltaTime);
            if (Input.GetButtonDown("Fire1"))
            {
                Vector3 mousePos = Input.mousePosition;
                {
                    if(mousePos.x > lastMouseX)
                    {
                        Debug.Log("right");
                        transform.position += Vector3.right;
                    } else
                    {
                        Debug.Log("left");
                        transform.position += Vector3.left;
                    }

                    var pos = transform.position;
                    pos.x = Mathf.Clamp(transform.position.x, -1.4f, 1.4f);
                    transform.position = pos;

                    lastMouseX = mousePos.x;
                }
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Collectable")
        {
            score = score + 5;
            scoreBoard.text = "Score: " + score;
        }
    }

}
