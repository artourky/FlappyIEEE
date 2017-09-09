using UnityEngine;
using UnityEngine.UI;

public class BirdMovement : MonoBehaviour {

    public static bool amIDead = false;
    public static int score = 0;

    public Image lessThan10;
    public Image moreThan10;
    public Image moreThan100;

    public Sprite[] numbers;

    public float jumpForce = 2f;
    public float maxForce = 5f;
    public float forwardSpeed = 1f;

    public Animator myAnimator;

    public bool godMode = false;

    public bool deletePrefs = false;

    Rigidbody2D myRigidbody;

    bool didFlap = false;

    int highScore = 0;

	// Use this for initialization
	void Start () {
        myRigidbody = GetComponent<Rigidbody2D>();

        if (deletePrefs)
        {
            PlayerPrefs.DeleteAll();
        }

        highScore = PlayerPrefs.GetInt("HighScore", 0);
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            didFlap = true;
        }

        if (score > highScore)
        {
            highScore = score;
            PlayerPrefs.SetInt("HighScore", highScore);
        }

        if (!amIDead)
        {
            if (score >= 100)
            {
                moreThan100.sprite = numbers[score / 100];
                moreThan10.sprite = numbers[(score % 100) / 10];
                lessThan10.sprite = numbers[((score % 100) % 10)];
            }
            else if (score >= 10)
            {
                moreThan10.sprite = numbers[score / 10];
                lessThan10.sprite = numbers[(score % 10)];
            }
            else
            {
                lessThan10.sprite = numbers[score];
            }
        }
	}

    private void FixedUpdate()
    {
        if (amIDead)
        {
            return;
        }

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

    public static void AddScore()
    {
        score++;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (godMode)
        {
            return;
        }

        amIDead = true;
        myAnimator.SetTrigger("hit");
    }
}
