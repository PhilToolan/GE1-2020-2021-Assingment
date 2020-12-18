using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ball : MonoBehaviour
{
    public Vector2 speed; //Ball only moves in 2d space
    public float speedMultiplier = 1;
    //public AudioSource audioSource;
    public AudioSource gameMusic;
    //public AudioClip hitSound;
    public Animator textAnimator;
    public Text text;
    public PongPlayer player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("PongPlayer").GetComponent<PongPlayer>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(speed.x, speed.y) * Time.deltaTime * speedMultiplier;

        //Check if Player missed the ball
        if (transform.position.x < -9 || transform.position.x > 9 || transform.position.y < -5 || transform.position.y > 5)
        {
            End();
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        //Debug.Log(col.gameObject.name);

        if (col.gameObject.name == "Paddle Floor")
        {
            speed.y = -speed.y; //Send Ball back (Vertical)
            HitEffect();
        }

        if (col.gameObject.name == "Paddle Wall")
        {
            speed.x = -speed.x; //Send Ball back (Horizontal)
            HitEffect();
        }
    }

    void HitEffect()
    {
        textAnimator.SetTrigger("effect");
        player.totalScore += 1;
        text.text = player.totalScore.ToString();
        //audioSource.pitch = Random.Range(0.8f, 1.3f);
        //audioSource.PlayOneShot(hitSound);
    }

    void End()
    {
        gameMusic.stop();
        transform.position = Vector3.zero;
        player.totalScore = 0;
        text.text = "Game Over !";

    }
}
