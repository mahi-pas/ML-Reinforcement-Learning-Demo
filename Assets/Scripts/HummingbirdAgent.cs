using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HummingbirdAgent : Agent
{
    public float moveForce = 2f;
    public float pitchSpeed = 100f;
    public float yawSpeed = 100f;
    public Transform beakTip;
    public Camera agentCamera;
    public bool trainingMode;

    new private Rigidbody rigidbody;
    private FlowerArea flowerArea;
    private Flower nearestFlower;
    private float smoothPitchChange = 0f;
    private float smoothYawChange = 0f;
    private float maxPitchAngle = 80f;
    private const float BeakTipRadius = 0.008f;
    private bool frozen = false;

    public float NectarObtained { get; private set; }

}
