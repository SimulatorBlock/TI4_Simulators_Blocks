using System;
using UnityEngine;

namespace Audio
{
    public class AudioManager : MonoBehaviour
    {
        public Sound[] sounds;
        public static AudioManager Instance;

        private void Awake()
        {
            if (Instance) Destroy(gameObject);
            else
            {
                Instance = this;
                DontDestroyOnLoad(gameObject);
            }
        }

        private void Start()
        {
            foreach (Sound s in sounds)
            {
                s.source = gameObject.AddComponent<AudioSource>();
                s.source.clip = s.clip;
                s.source.volume = s.volume;
                s.source.pitch = s.pitch;
            }
        }

        public void Play(string n)
        {
            Sound s = Array.Find(sounds, sound => sound.name == n);
            s.source.Play();
        }

        public void Pause(string n)
        {
            Sound s = Array.Find(sounds, sound => sound.name == n);
            s.source.Pause();
        }

        public void ButtonClick()
        {
            Play("ButtonClick");
        }

        public void ButtonHover()
        {
            Play("ButtonHover");
        }
    }
}
