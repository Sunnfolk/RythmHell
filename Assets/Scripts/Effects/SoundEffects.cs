using UnityEngine;

namespace Effects
{
    public class SoundEffects : MonoBehaviour
    {
        [SerializeField] private AudioClip hitSound;

        [SerializeField] private AudioSource sound;
    
    
        private void Awake()
        {
            //sound = GetComponent<AudioSource>();
        }

        public void HitSound()
        {
            //m_Audio.pitch = Random.Range(0.9f, 1.1f);
            sound.PlayOneShot(hitSound);
        }
    }
}
