using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SoundManager : MonoBehaviour
{

    public static bool SoundOn = true;

    [Serializable]
    public class Sounds
    {
        public Constants.Sound sound;
        public AudioClip audioClip;
        public AudioSource audioSorce;
    }

    public Sounds[] mySounds;
    public static SoundManager _i;
    public AudioSource backGroundMusic;


    void Start()
    {
        _i = this;
        backGroundMusic.playOnAwake = false;
        backGroundMusic.loop = true;

        int len = mySounds.Length;
        for (int i = 0; i < len; i++)
        {
            mySounds[i].audioSorce = gameObject.AddComponent<AudioSource>();
            mySounds[i].audioSorce.clip = mySounds[i].audioClip;
        }
    }

    private void Update()
    {
        if (SoundOn)
        {
            backGroundMusic.volume = 0.5f;
        }

        else
        {
            backGroundMusic.volume = 0.0f;
        }
    }

    public static SoundManager i()
    {
        return _i;
    }

    public void playOnce(Constants.Sound sound)
    {
        if (SoundOn)
        {
            for (int i = 0; i < mySounds.Length; i++)
            {
                if (sound == mySounds[i].sound)
                {
                    if (mySounds[i].audioSorce.isPlaying) mySounds[i].audioSorce.Stop();
                    mySounds[i].audioSorce.Play();
                }
            }
        }
    }

    public void stopPlaySound(Constants.Sound sound)
    {
        for (int i = 0; i < mySounds.Length; i++)
        {
            if (sound == mySounds[i].sound)
            {
                if (mySounds[i].audioSorce.isPlaying) mySounds[i].audioSorce.Stop();
            }
        }
    }

    public void playBackGroundMusic()
    {
        backGroundMusic.Play();
    }

}  //class