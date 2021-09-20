using UnityEngine;
using System.Collections;

public class PlayerSpawner : MonoBehaviour {
    
    public GameObject player;
    public Sprite[] sprites;

    private SpriteRenderer spriteRenderer;

    // Use this for initialization
    void Start () {
        spriteRenderer = player.GetComponent<SpriteRenderer>();

        Instantiate(player);

        spriteRenderer.sprite = sprites[Random.Range(0, sprites.Length)];
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
