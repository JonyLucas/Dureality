using UnityEngine;

namespace Game.Audio
{
    /// <summary>
    /// This class is used by audioManager to create a array of audioSources, here you can set which components you can manipulate on Audio Manager prefab.
    /// </summary>
    [System.Serializable]
    public class SoundFx
    {
        [SerializeField]
        private AudioClip _clip;

        [SerializeField]
        [Range(-3, 3)]
        private float _pitch;

        public string Name
        { get { return _clip != null ? _clip.name : string.Empty; } }

        public AudioClip Clip
        { get { return _clip; } }

        public float Pitch
        { get { return _pitch; } }

        public AudioSource Source { get; set; }
    }
}