using UnityEngine;

public class SkyDelay : MonoBehaviour {

    public float speed = -0.1f;

    public BirdMovement player;

    void FixedUpdate () {
        if (!BirdMovement.amIDead)
        {
            speed = player.forwardSpeed - 0.1f;
            Vector3 pos = transform.position;
            pos.x += speed * Time.fixedDeltaTime;
            transform.position = pos; 
        }
	}
}
