using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplaySettings : MonoBehaviour {

    public Dropdown resolutionDD;

    Resolution[] resolutionArray;

    private void Start()
    {
        resolutionArray = Screen.resolutions;
        resolutionDD.ClearOptions();
        List<string> settings = new List<string>();
        int currentRes = 0;

        for (int i = 0; i < resolutionArray.Length; i++)
        {
            string setting = resolutionArray[i].width + " x " + resolutionArray[i].height;
            settings.Add(setting);

            if (resolutionArray[i].width == Screen.currentResolution.width && resolutionArray[i].height == Screen.currentResolution.height)
            {
                currentRes = i;
            }
        }

        resolutionDD.AddOptions(settings);
        resolutionDD.value = currentRes;
        resolutionDD.RefreshShownValue();
    }

    public void SetResolution(int Res)
    {
        Resolution actualResolution = resolutionArray[Res];
        Screen.SetResolution(actualResolution.width, actualResolution.height, Screen.fullScreen);
    }

    public void SetQuality(int qualityInteger)
    {
        QualitySettings.SetQualityLevel(qualityInteger);
        
    }

    public void SetFullscreen(bool isFull)
    {
        Screen.fullScreen = isFull;
    }
}
