using UnityEngine;
using System.Collections;

public class BackgroundSpawner : MonoBehaviour {

    public GameObject background;

    private GameObject back;

	// Use this for initialization
	void Start () {
        back = Instantiate(background);
        back.transform.position = new Vector3(0, 0, 0);
	}
	
	// Update is called once per frame
	void Update () {
        if (back.transform.position.x <= 0)
        {
            back = Instantiate(background);
            back.transform.position = new Vector3(transform.position.x, 0, 0);
        }
	}
}
