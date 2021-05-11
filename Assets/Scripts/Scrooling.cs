using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scrooling : MonoBehaviour
{
    public float speed;

    float currentTime =0;

    // Update is called once per frame
    void Update()
    {
        if(!GameManager.instance.isGameOver)
        {
            transform.Translate(Vector3.back * speed * Time.deltaTime);
        }

        currentTime += Time.deltaTime;

        if (currentTime > 10)
        {
            speed += 3f;
            currentTime = 0;
        }
            


        if (speed > 50)
            speed = 50;
    }
}
