using UnityEngine;

public class SkyDelay : MonoBehaviour {

    public float speed = -0.1f;

    public BirdMovement player;

    void FixedUpdate () {
        if (!player.amIDead)
        {
            Vector3 pos = transform.position;
            pos.x += speed * Time.fixedDeltaTime;
            transform.position = pos; 
        }
	}
}
