using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerMovement2 : MonoBehaviour
{

    public float speed;
    public Rigidbody playerRigidbody;
    public GameObject Coin;
    public int score;
    public Text scoretext;

    // Start is called before the first frame update
    void Start()
    {

        score = 0;


    }

    // Update is called once per frame
    void Update()
    {
        scoretext.text = "Coins Collected  " + score;
        if (score == 4)
        {
            SceneManager.LoadScene("WinScene");
        }
    }
    void FixedUpdate()
    {
        float MoveHorizontal = Input.GetAxis("Horizontal");
        float MoveVertical = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(MoveHorizontal, 0, MoveVertical);
        transform.Translate(movement * Time.deltaTime * speed);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Hazzard")
        {
            SceneManager.LoadScene("GameLose");
        }
        if (collision.gameObject.tag == "Coins")
        {
            Destroy(Coin);
            score++;
        }
    }
}
