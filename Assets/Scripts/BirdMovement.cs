using UnityEngine;

public class BirdMovement : MonoBehaviour {

    public float jumpForce = 2f;
    public float maxForce = 5f;
    public float forwardSpeed = 1f;

    Rigidbody2D myRigidbody;

    bool didFlap = false;

	// Use this for initialization
	void Start () {
        myRigidbody = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            didFlap = true;
        }
	}

    private void FixedUpdate()
    {
        myRigidbody.velocity = new Vector2(forwardSpeed, myRigidbody.velocity.y);

        float angle = 0f;

        if (didFlap)
        {
            didFlap = false;

            if (myRigidbody.velocity.y < 0)
            {
                myRigidbody.velocity = new Vector2(myRigidbody.velocity.x, 0f);
            }

            myRigidbody.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
            myRigidbody.velocity = Vector3.ClampMagnitude(myRigidbody.velocity, maxForce);
        }

        if (myRigidbody.velocity.y < 0)
        {
            angle = Mathf.Lerp(0, -90, -myRigidbody.velocity.y / maxForce);
        }
        else
        {
            angle = Mathf.Lerp(0, 90, myRigidbody.velocity.y / maxForce);
        }

        transform.rotation = Quaternion.Euler(0f, 0f, angle);
    }
}
