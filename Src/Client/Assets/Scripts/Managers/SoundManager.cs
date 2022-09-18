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
        /// ���������󣬴˶���Ӧ���ⲿ���û��޸�
        /// </summary>
        public AudioMixer audioMixer;
        /// <summary>
        /// ���ֵĻ���ͨ�����󣬴˶���Ӧ���ⲿ���û��޸�
        /// </summary>
        public AudioSource musicAudioSource;
        /// <summary>
        /// ��Ч�Ļ���ͨ�����󣬴˶���Ӧ���ⲿ���û��޸�
        /// </summary>
        public AudioSource soundAudioSource;

        private const string MusicPath = "Music/";//���ֵ���Դ·��
        private const string SoundPath = "Sound/";//��Ч����Դ·��

        private int musicVolume;//��������������С
        private int soundVolume;//������Ч������С
        private bool musicOn;//�������ֿ�����ر�
        private bool soundOn;//������Ч������ر�

        /// <summary>
        /// ��ʾ����������С��ֵ
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
        /// ��ʾ��Ч������С��ֵ
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
        /// ��ȡ���������ֵĿ���
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
        /// ��ȡ��������Ч�Ŀ���
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
        /// ��������
        /// </summary>
        /// <param name="name">�����ļ���</param>
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
        /// ������Ч
        /// </summary>
        /// <param name="name">��Ч�ļ���</param>
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
        /// δʵ��
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
