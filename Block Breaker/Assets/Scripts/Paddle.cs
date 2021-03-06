﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour {

    public bool autoPlay = true;

    private Ball ball;

    void Start()
    {
        ball = GameObject.FindObjectOfType<Ball>();
        print(ball);
    }


    void Update () {
        if (autoPlay == true)
        {
            MoveWithMouse();
        } else
        {
            AutoPlay();
        }
	}

    void MoveWithMouse()
    {
        Vector3 paddlePos = new Vector3(0.5f, this.transform.position.y, 0f);
        Vector3 ballPos = ball.transform.position;
        paddlePos.x = Mathf.Clamp(ballPos.x, 0.931f, 15.076f);
        this.transform.position = paddlePos;
    }

    void AutoPlay()
    {
        Vector3 paddlePos = new Vector3(0.5f, this.transform.position.y, 0f);
        float mousePosInBlock = Input.mousePosition.x / Screen.width * 16;
        paddlePos.x = Mathf.Clamp(mousePosInBlock, 0.931f, 15.076f);
        this.transform.position = paddlePos;
    }
}
