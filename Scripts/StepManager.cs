using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StepManager : MonoBehaviour
{
    public TextMeshProUGUI stepText; // UI ≈ÿΩ∫∆Æ
    private int currentStep = 0;

    void Start()
    {
#if UNITY_ANDROID && !UNITY_EDITOR
        try
        {
            using (AndroidJavaClass unityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer"))
            {
                AndroidJavaObject activity = unityPlayer.GetStatic<AndroidJavaObject>("currentActivity");
                AndroidJavaObject plugin = new AndroidJavaObject("com.example.stepplugin1.StepCounterPlugin1", activity);

                plugin.Call("startTracking");
                Debug.Log("Android Plugin Started");
            }
        }
        catch (System.Exception e)
        {
            Debug.LogError("Android Plugin Failed: " + e.Message);
        }
#endif
    }

    public void OnStepChanged(string stepStr)
    {
        currentStep = int.Parse(stepStr);
        UpdateStepUI();
        Debug.Log("Steps: " + currentStep);
    }

    void UpdateStepUI()
    {
        stepText.text = $"Steps: {currentStep}";
    }
}
