using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerController : MonoBehaviour
{

    public bool start = false;
    public float score;
    public float moveSpeed;
    public bool isInvisible = false;
    public TextMeshProUGUI scoreText;
    public GameObject gameOverPanel;
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
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Collectable")
        {
            score = score + 5;
            Destroy(other.gameObject, 0f);
        }
        if(other.tag == "Enemy")
        {
            if (!isInvisible)
            {
                score = score - 5;
                Destroy(other.gameObject, 0f);
            }
        }
        if(other.tag == "FinishLine")
        {
            scoreText.text = "Score: " + score;
            gameOverPanel.SetActive(true);
            Time.timeScale = 0;
        }
        if(other.tag == "InvisibleMaker")
        {
            isInvisible = true;
            Destroy(other.gameObject, 0f);
            StartCoroutine(MakeUserVisible());
        }
        if(other.tag == "Booster")
        {
            float defaultSpeed = moveSpeed;
            moveSpeed = moveSpeed * 2;
            Destroy(other.gameObject, 0f);
            StartCoroutine(EndBoosting(defaultSpeed));
        }
    }

    private IEnumerator EndBoosting(float speed)
    {
        yield return new WaitForSeconds(2f);
        moveSpeed = speed;
    }

    private IEnumerator MakeUserVisible()
    {
        yield return new WaitForSeconds(2f);
        isInvisible = false;
    }


}
