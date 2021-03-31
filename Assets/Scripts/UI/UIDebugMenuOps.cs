using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIDebugMenuOps : MonoBehaviour
{
    private Slider slider;

    private void Start()
    {
        slider = GetComponent<Slider>();
        switch (gameObject.tag)
        {
            case "UISliderForwardSpeed":
                slider.value = Constants.PlayerForwardSpeed / (Constants.PlayerForwardSpeedMax - Constants.PlayerForwardSpeedMin);
                break;
            case "UISliderSideSpeed":
                slider.value = Constants.PlayerForwardSpeed / (Constants.PlayerForwardSpeedMax - Constants.PlayerForwardSpeedMin);
                break;
            case "UISliderCrackForceUp":
                // we are using different logic
               // slider.value = Constants.CrackForceUp / (Constants.CrackForceUpMax - Constants.CrackForceUpMin);
                break;
            case "UISliderCameraOffSetX":
                slider.value = Mathf.Abs((Constants.CameraOffSetX - Constants.CameraOffSetXMin) / (Constants.CameraOffSetXMax - Constants.CameraOffSetXMin));
                break;
            case "UISliderCameraOffSetY":
                slider.value = Mathf.Abs((Constants.CameraOffSetY - Constants.CameraOffSetYMin) / (Constants.CameraOffSetYMax - Constants.CameraOffSetYMin));
                break;
            case "UISliderCameraOffSetZ":
                slider.value = Mathf.Abs((Constants.CameraOffSetZ - Constants.CameraOffSetZMin) / (Constants.CameraOffSetZMax - Constants.CameraOffSetZMin));
                break;

        }
    }

    public void ChangeSlider()
    {
        switch (gameObject.tag)
        {
            case "UISliderForwardSpeed":
                Constants.PlayerForwardSpeed = (slider.value * (Constants.PlayerForwardSpeedMax - Constants.PlayerForwardSpeedMin)) + Constants.PlayerForwardSpeedMin;
                break;
            case "UISliderSideSpeed":
                Constants.PlayerSideSpeed = (slider.value * (Constants.PlayerSideSpeedMax - Constants.PlayerSideSpeedMin)) + Constants.PlayerSideSpeedMin;
                break;
            case "UISliderCrackForceUp":
                // we are using different logic
                // Constants.CrackForceUp = (slider.value * (Constants.CrackForceUpMax - Constants.CrackForceUpMin)) + Constants.CrackForceUpMin;
                break;
            case "UISliderCameraOffSetX":
                Constants.CameraOffSetX = (slider.value * (Constants.CameraOffSetXMax - Constants.CameraOffSetXMin)) + Constants.CameraOffSetXMin;
                break;
            case "UISliderCameraOffSetY":
                Constants.CameraOffSetY = (slider.value * (Constants.CameraOffSetYMax - Constants.CameraOffSetYMin)) + Constants.CameraOffSetYMin;
                break;
            case "UISliderCameraOffSetZ":
                Constants.CameraOffSetZ = (slider.value * (Constants.CameraOffSetZMax - Constants.CameraOffSetZMin)) + Constants.CameraOffSetZMin;
                break;

        }
    }
}
