﻿using UnityEngine;

public class LoopingBG : MonoBehaviour {

    public int bgNumber = 5;

    float pipeMax = 1.2f;
    float pipeMin = -0.21f;

    private void Start()
    {
        GameObject[] pipes = GameObject.FindGameObjectsWithTag("Pipe");

        foreach (GameObject pipe in pipes)
        {
            Vector3 pos = pipe.transform.position;
            pos.y = Random.Range(pipeMin, pipeMax);
            pipe.transform.position = pos;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //print(collision.name);
        if (collision.tag == "IGNOREME")
        {
            collision.transform.position = new Vector3(3.92f, collision.transform.position.y, collision.transform.position.z);
            return;
        }
        
        float widthOfBGObj = ((BoxCollider2D)collision).size.x;

        Vector3 pos = collision.transform.localPosition;
        pos.x += (widthOfBGObj * bgNumber) - (0.01f * bgNumber);

        if (collision.tag == "Pipe")
        {
            pos.y = Random.Range(pipeMin, pipeMax);
        }

        collision.transform.localPosition = pos;
    }
}
