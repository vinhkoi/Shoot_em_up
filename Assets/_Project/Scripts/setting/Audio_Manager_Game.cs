using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

namespace Shmup
{
    public class Audio_Manager_Game : MonoBehaviour
    {
        [Header("----- Audio Source -----")]
        [SerializeField] AudioSource musicSource;
        [SerializeField] AudioSource SFXSource;

        [Header("----- Audio Clip -----")]
        public AudioClip shootSound;
        public AudioClip rocketSound;
        public AudioClip explosion;
        public AudioClip background;

        [SerializeField]
        private AudioMixer MyMixer;

        private void Start()
        {
            musicSource.clip = background;
            musicSource.Play();

            if (PlayerPrefs.HasKey("VolumeVolume") && PlayerPrefs.HasKey("MusicVolume") && PlayerPrefs.HasKey("SFXVolume"))
            {
                LoadVolume();
            }
            else
            {

            }
        }

        public void playSFX(AudioClip clip)
        {
            SFXSource.PlayOneShot(clip);
        }
        private void LoadVolume()
        {
            // Lấy giá trị âm lượng từ PlayerPrefs
            float masterVolume = PlayerPrefs.GetFloat("VolumeVolume");
            float musicVolume = PlayerPrefs.GetFloat("MusicVolume");
            float sfxVolume = PlayerPrefs.GetFloat("SFXVolume");

            // Cài đặt âm lượng cho AudioMixer
            MyMixer.SetFloat("Volume", Mathf.Log10(masterVolume) * 20);
            MyMixer.SetFloat("Music", Mathf.Log10(musicVolume) * 20);
            MyMixer.SetFloat("SFX", Mathf.Log10(sfxVolume) * 20);
        }
    }

}
