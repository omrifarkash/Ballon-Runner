using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Constants
{
    // Player
    public static int PlayerStartsCountBlloon = 1;
    public static int PlayerMaxBalloonCount = 50;

    public static float PlayerForwardSpeedMax = 70f;
    public static float PlayerForwardSpeed = 30f;
    public static float PlayerForwardSpeedAtStart = 30f;
    public static float PlayerForwardSpeedLowDown = 15f;
    public static float PlayerForwardSpeedMin = 0f;

    public static float PlayerSideSpeedMax = 0.4f;
    public static float PlayerSideSpeed = 0.2f;
    public static float PlayerSideSpeedMin = 0f;

    public static float PlayerFlyingForceMultiplier = 4f;

    //gazer obstacle,  always keep gazerTimer == gazerTimerMax !
    public static float gazerTimer = 3f;
    public static float gazerTimerMax = 3f;
    public static float gazerSpeed = 25f;


    // Camera
    public static float CameraOffSetXMax = 100;
    public static float CameraOffSetX = 0;
    public static float CameraOffSetXMin = -100;
    public static float CameraOffSetYMax = 100;
    public static float CameraOffSetY = 13;
    public static float CameraOffSetYMin = -100;
    public static float CameraOffSetZMax = 100;
    public static float CameraOffSetZ = -25;
    public static float CameraOffSetZMin = -100;
    public static Vector3 CameraOnPlayOffset = new Vector3(CameraOffSetX, CameraOffSetY, CameraOffSetZ);
    public static float CameraChangeFiledOfViewSpeed = 1.5f;
    public static float CameraFiledOfViewValue = 75f;

    public static float CoinSpeedToUI = 1500f;

    public static float PlainEnvSpeed = 10f;

    public static float ToturialTimeAfterSwipe = 0.25f;
    public static float ToturialTimeAfterTakeCoins = 3.9f;
    public static float ToturialTimeAfterTakeBallons = 7.5f;

    //Slider
    public static float SliderEnviromentHeightDifference = 250;

    //moving platform constants
    public static float MovingPlatformMoveRange = 35f;
    public static float MovingPlatformMoveSpeed = 12f;

    //slider Obstacle 
    public static float SliderObstacleMovePlayerSpeed = 10f;

    // Player Pref Names
    public static readonly string PPUserCoins = "UserCoins";

    public static readonly int MaxLevelNumber = 3;

    public enum Sound
    {
        coin_collected,
        balloon_poped,
        on_air,
        backGroundMusic,
        completeLVL,
    }
}
