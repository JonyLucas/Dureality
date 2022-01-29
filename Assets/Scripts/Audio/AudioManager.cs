using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

namespace Game.Audio
{
    /// <summary>
    /// Class that create a array of AudioSource, can be used mainly on scripts to call audios of this prefab.
    /// </summary>
    public class AudioManager : MonoBehaviour
    {
        [SerializeField]
        private List<SoundFx> _sounds;

        [SerializeField]
        private Slider _volumeFX;

        [SerializeField]
        private Slider _volumeMusic;

        [SerializeField]
        private AudioClip _backgroundMusicClip;

        private AudioSource _backgroundSource;

        // Use this for initialization
        private void Awake()
        {
            // Creates the background audio source
            _backgroundSource = gameObject.AddComponent<AudioSource>();
            _backgroundSource.clip = _backgroundMusicClip;
            _backgroundSource.loop = true;
            _backgroundSource.Play();

            // Creates the sound fxs audio sources
            _sounds.ForEach(s =>
            {
                s.Source = gameObject.AddComponent<AudioSource>();
                s.Source.clip = s.Clip;
            });
        }

        private void Start()
        {
            _volumeFX.value = PlayerPrefs.GetFloat("volumeFX", 0.4f);
            _volumeMusic.value = PlayerPrefs.GetFloat("volumeMusic", 1.0f);
            _sounds.ForEach(x => x.Source.volume = _volumeFX.value);
            _backgroundSource.volume = _volumeMusic.value;
        }

        public void ChangeSoundFxVolume(float volume)
        {
            PlayerPrefs.SetFloat("volumeFX", volume);
            _sounds.ForEach(x => x.Source.volume = volume);
        }

        public void ChangeBackgroundMusicVolume(float volume)
        {
            PlayerPrefs.SetFloat("volumeMusic", volume);
            _backgroundSource.volume = volume;
        }

        public void Play(string name)
        {
            var sound = _sounds.FirstOrDefault(sound => sound.Name == name);

            if (sound != null)
            {
                sound.Source.Play();
            }
        }
    }
}