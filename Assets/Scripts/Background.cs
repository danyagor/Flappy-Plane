using UnityEngine;
using System.Collections;

public class Background : MonoBehaviour {

    public Vector2 velocity = new Vector2(-1f, 0f);

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
	}
	
	// Update is called once per frame
	void Update () {
        if (transform.position.x <= -15.0f)
        {
            Destroy(gameObject);
        }
	}

    void GameOver()
    {
        rb.velocity = Vector2.zero;
    }
}
