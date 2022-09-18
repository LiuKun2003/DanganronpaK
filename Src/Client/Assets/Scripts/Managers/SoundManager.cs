using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using System;

namespace Managers
{
    public class SoundManager : MonoSingleton<SoundManager>
    {
        /// <summary>
        /// 混音器对象，此对象不应被外部调用或修改
        /// </summary>
        public AudioMixer audioMixer;
        /// <summary>
        /// 音乐的混音通道对象，此对象不应被外部调用或修改
        /// </summary>
        public AudioSource musicAudioSource;
        /// <summary>
        /// 音效的混音通道对象，此对象不应被外部调用或修改
        /// </summary>
        public AudioSource soundAudioSource;

        private const string MusicPath = "Music/";//音乐的资源路径
        private const string SoundPath = "Sound/";//音效的资源路径

        private int musicVolume;//控制音乐声音大小
        private int soundVolume;//控制音效声音大小
        private bool musicOn;//控制音乐开启或关闭
        private bool soundOn;//控制音效开启或关闭

        /// <summary>
        /// 表示音乐声音大小的值
        /// </summary>
        public int MusicVolume
        {
            get
            {
                return musicVolume;
            }
            set
            {
                if (value > 100)
                    musicVolume = 100;
                else if (value < 0)
                    musicVolume = 0;
                else
                    musicVolume = value;
            }
        }
        /// <summary>
        /// 表示音效声音大小的值
        /// </summary>
        public int SoundVolume
        {
            get
            {
                return soundVolume;
            }
            set
            {
                if (value > 100)
                    soundVolume = 100;
                else if (value < 0)
                    soundVolume = 0;
                else
                    soundVolume = value;
            }
        }
        /// <summary>
        /// 获取或设置音乐的开关
        /// </summary>
        public bool MusicOn
        {
            get
            {
                return musicOn;
            }
            set
            {
                musicOn = value;
                MusicMute(musicOn);
            }
        }
        /// <summary>
        /// 获取或设置音效的开关
        /// </summary>
        public bool SoundOn
        {
            get
            {
                return soundOn;
            }
            set
            {
                soundOn = value;
                MusicMute(musicOn);
            }
        }
        
        private void SoundMute(bool on)
        {
            SetVolume("SoundVolume", soundVolume);
        }
        private void MusicMute(bool on)
        {
            SetVolume("MusicVolume", soundVolume);
        }
        private void SetVolume(string name, int value)
        {
            float volume = value * 0.5f + 50f;
            audioMixer.SetFloat(name, volume);
        }

        /// <summary>
        /// 播放音乐
        /// </summary>
        /// <param name="name">音乐文件名</param>
        public void PlayMusic(string name)
        {
            AudioClip clip = Resloader.Load<AudioClip>(MusicPath + name);
            if(clip == null)
            {
                Debug.LogWarningFormat("PlayMusic : {0} not existed", name);
                return;
            }
            if(musicAudioSource.isPlaying)
            {
                musicAudioSource.Stop();
            }

            musicAudioSource.clip = clip;
            musicAudioSource.Play();
        }
        /// <summary>
        /// 播放音效
        /// </summary>
        /// <param name="name">音效文件名</param>
        public void PlaySound(string name)
        {
            AudioClip clip = Resloader.Load<AudioClip>(SoundPath + name);
            if (clip == null)
            {
                Debug.LogWarningFormat("PlaySound : {0} not existed", name);
                return;
            }
            soundAudioSource.PlayOneShot(clip);
        }
        /// <summary>
        /// 未实现
        /// </summary>
        /// <param name="source"></param>
        /// <param name="clip"></param>
        /// <param name="isLoop"></param>
        protected void PlayClipOnAudioSource(AudioSource source, AudioClip clip, bool isLoop)
        {
            throw new NotImplementedException();
        }
    }
}
