using System;
using UnityEngine;
using UnityEngine.Audio;

namespace SRS.Audio
{
    [System.Serializable]
    public class Sound
    {
        public string Name;
        public AudioClip Clip;
        [Range(0, 1)] public float Volume;

        [HideInInspector] public AudioSource Source;
    }
}
