using UnityEngine;
using System.Collections;

public class Obstacle : MonoBehaviour {

    public Vector2 velocity = new Vector2(-4, 0);

    private Rigidbody2D rb;

    void Awake()
    {
        Messenger.AddListener(GameEvents.GAME_OVER, GameOver);
    }
    void OnDestroy()
    {
        Messenger.RemoveListener(GameEvents.GAME_OVER, GameOver);
    }

    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = velocity;

        Invoke("Destroy", 4.0f);
	}
	
	// Update is called once per frame
	void Update () {
	    
	}

    void StartGame()
    {

    }

    void GameOver()
    {
        rb.velocity = Vector2.zero;
        CancelInvoke();
    }

    void Destroy()
    {
        Destroy(gameObject);
    }
}
