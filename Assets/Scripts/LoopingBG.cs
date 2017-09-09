using UnityEngine;

public class LoopingBG : MonoBehaviour {

    public int bgNumber = 5;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //print(collision.name);

        float widthOfBGObj = ((BoxCollider2D)collision).size.x;

        Vector3 pos = collision.transform.localPosition;
        pos.x += (widthOfBGObj * bgNumber) - (0.01f * bgNumber);

        collision.transform.localPosition = pos;
    }
}
