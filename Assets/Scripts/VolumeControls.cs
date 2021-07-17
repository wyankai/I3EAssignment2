/******************************************************************************
Author: Syakir(S10204929) and Yankai(S10206089)

Name of Class: VolumeControls

Description of Class: This class will control the audio in the game

Date Created: 07/07/2021
******************************************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class VolumeControls : MonoBehaviour
{
    public AudioMixer mixer;

    public void SetLevel(float sliderValue)
    {
        mixer.SetFloat("MusicVol", Mathf.Log10(sliderValue) * 20);
    }
}

