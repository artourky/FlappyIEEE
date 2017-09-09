using UnityEngine;

public class ScoreBox : MonoBehaviour {

    bool canIAddScore = true;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (canIAddScore && !BirdMovement.amIDead)
        {
            canIAddScore = false;
            BirdMovement.AddScore();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        canIAddScore = true;
    }
}
