using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

    private ParticleSystem particleSyst;

    public Vector2 jumpForce = new Vector2(0, 300);
    public ParticleSystem explosionSystem;

    private Rigidbody2D rb;
    private int score = 0;
    private bool gameOver = false;


    void Awake()
    {
        Messenger.AddListener(GameEvents.GAME_STARTED, GameStarted);
    }
    void OnDestroy()
    {
        Messenger.RemoveListener(GameEvents.GAME_STARTED, GameStarted);
    }

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();
        rb.constraints = RigidbodyConstraints2D.FreezePositionY;
        particleSyst = explosionSystem;
        particleSyst.Simulate(0.5f);
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0) && gameOver != true)
        {
            rb.velocity = Vector2.zero;
            rb.AddForce(jumpForce);
        }
	}

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "DieCollider")
        {
            

            if (gameOver != true)
            {
                Messenger.Broadcast(GameEvents.GAME_OVER);
            }
            gameOver = true;
            Invoke("DestroyPlane", 1.0f);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "ScoreTrigger")
        {
            score++;
            Messenger<int>.Broadcast(GameEvents.SCORED, score);
        }

        if (other.gameObject.tag == "RockCollider")
        {
            gameOver = true;
            Messenger.Broadcast(GameEvents.GAME_OVER);
        }
    }

    void GameStarted()
    {
        rb.constraints = RigidbodyConstraints2D.None;
    }

    void Die()
    {
        
    }

    void DestroyPlane()
    {
        Destroy(gameObject);
    }
}
