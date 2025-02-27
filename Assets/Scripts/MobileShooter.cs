﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class MobileShooter : MonoBehaviour {
    public Button ShootFrontButton;
    private GameObject phoneCube, phoneCube2;
    private TargetBehavior targetBehavior;

    bool started = false;
    float swipespeed_min = 1;
    Vector3 mousedown_pos;
    float mousedowned_time;
    Vector3 swipe_vel;

    bool bMouseDown = false;
    float ballSpeedFixed = 25f;

    private void Start()
    {
        targetBehavior = FindObjectOfType<TargetBehavior>();
		ShootFrontButton.enabled = false;
    }

    public void Activate()
    {
        ShootFrontButton.enabled = true;
        ShootFrontButton.onClick.AddListener(ShootBallFront);
        started = true;

        phoneCube = PhotonNetwork.Instantiate("PhoneCubeTransparent", new Vector3(0.0f, 0.0f, 0.0f), Quaternion.identity, 0);
    }

    // shoot ball on swipe
    private void Update()
    {
        if (!started) return;

        phoneCube.transform.position = targetBehavior.GetPhonePosition();
        phoneCube.transform.rotation = targetBehavior.GetPhoneRotation();

        if (bMouseDown)
        {
            mousedowned_time += Time.deltaTime;
        }

        if (!bMouseDown && Input.GetMouseButtonDown(0))
        {
            mousedown_pos = Input.mousePosition;
            mousedowned_time = 0;
            bMouseDown = true;
        }

        // TODO-3.1.b
        // The following method for detecting finger swipes has been implemented for you.
        if (Input.GetMouseButtonUp(0))
        {
            if (!bMouseDown || mousedowned_time <= 0.05f) return;

            Vector3 mouseup_pos = Input.mousePosition;
            Vector3 delta = (mouseup_pos - mousedown_pos) / Screen.height;
            swipe_vel = delta / mousedowned_time;

            if (swipe_vel.y > swipespeed_min) {
                ShootBallUp();
            }

            bMouseDown = false;
            mousedowned_time = 0;
        }
    }

    public void ShootBall(Vector3 velocity)
    {
        GetComponent<AudioSource>().Play();

        // You may want to use a random nice color so there is one!
        Color color = Random.ColorHSV(0f, 1f, 0.5f, 1f, 0.5f, 1f, 1f, 1f);
        Vector3 color_v = new Vector3(color.r, color.g, color.b);

        // TODO-2.c PhotonNetwork.Instantiate to shoot a ball!
        // You may want to initialize a RPC function call to RPCInitialize() 
        //   (See BallBehavior.cs) to set the velocity and color
        //   of the ball across all clients (PhotonTargets.All) and transfer 
        //   the ownership of the ball to PC so the ball is correctly destroyed
        //   upon hitting a wall.
        
        Vector3 pos = targetBehavior.GetPhonePosition();
        GameObject ballObj = PhotonNetwork.Instantiate("ball", pos, Quaternion.identity, 0) as GameObject;
       PhotonView pv = ballObj.GetComponent<PhotonView>();
        pv.RPC("RPCInitialize", PhotonTargets.All, velocity, color_v);
    }

    public void ShootBallFront()
    {
        ShootBall(ballSpeedFixed * targetBehavior.GetPhoneForward());
    }

    public void ShootBallUp() {
        ShootBall(swipe_vel.y * ballSpeedFixed * targetBehavior.GetPhoneUp());
    }
}
