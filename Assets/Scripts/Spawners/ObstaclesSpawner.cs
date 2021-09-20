using UnityEngine;
using System.Collections;

public class ObstaclesSpawner : MonoBehaviour {

    public GameObject rocks;
    public Vector2 randomSpawnRange = new Vector2(-2.1f, 2.1f);

    void Awake()
    {
        Messenger.AddListener(GameEvents.GAME_STARTED, GameStarted);
        Messenger.AddListener(GameEvents.GAME_OVER, GameOver);
    }
    void OnDestroy()
    {
        Messenger.RemoveListener(GameEvents.GAME_STARTED, GameStarted);
        Messenger.RemoveListener(GameEvents.GAME_OVER, GameOver);
    }

    // Use this for initialization
    void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void GameStarted()
    {
        //Debug.Log("GAME STARTED");
        InvokeRepeating("CreateObstacle", 1f, 2f);
    }

    void GameOver()
    {
        CancelInvoke();
    }

    void CreateObstacle()
    {
        Instantiate(rocks);
        rocks.transform.position = new Vector3(transform.position.x, Random.Range(randomSpawnRange.x, randomSpawnRange.y), transform.position.z);
    }
}
