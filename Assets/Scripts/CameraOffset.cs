using UnityEngine;

public class CameraOffset : MonoBehaviour {

    public Transform player;

    float offsetX;

	// Use this for initialization
	void Start () {
        if (player)
        {
            offsetX = transform.position.x - player.position.x;
            print(offsetX);
        }
	}
	
	// Update is called once per frame
	void Update () {
        if (player)
        {
            Vector3 pos = transform.position;
            pos.x = player.position.x + offsetX;
            transform.position = pos;
        }
    }
}
