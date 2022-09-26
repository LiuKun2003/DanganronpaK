using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Define;
using Views;
using UnityEngine;

namespace Managers
{
    public class StoryManager : MonoSingleton<StoryManager>
    {
        private Dictionary<int , Dictionary<int, StoryDefine>> story;
        /// <summary>
        /// 剧情UI对象，此对象不应被外部调用或修改
        /// </summary>
        public UIStory storyView;
        /// <summary>
        /// 剧情结束时的回调函数
        /// </summary>
        public event Action StoryEnd;
        /// <summary>
        /// 获取一个值，此值指示了是否正在进行剧情中
        /// </summary>
        public bool IsStory { get; private set; }
        /// <summary>
        /// 获取或设置一个值，此值指示了是否自动播放
        /// </summary>
        public bool IsAuto { get; set; }
        /// <summary>
        /// 获取或设置一个值，此值指示了自动播放时会等待的时间（以秒为单位）
        /// </summary>
        public float WaitTimeForAuto { get; set; }
        /// <summary>
        /// 加载所需要的配置文件，所有的剧情都会基于最后一次读取的配置
        /// </summary>
        /// <param name="name"></param>
        public void LoadStoryDefine(string name)
        {
            story = DataManager.Instance.LoadStoryDefine(name);
        }
        /// <summary>
        /// 以指定的索引开始一段剧情
        /// </summary>
        /// <param name="startIndex">开始的索引</param>
        public void StoryStart(int startIndex)
        {
            if(!story.ContainsKey(startIndex))
            {
                Debug.LogErrorFormat("StoryManager[{0}] : 当前配置文件找不到索引为'{1}'的剧情!", GetInstanceID(), startIndex);
                return;
            }
            if(IsStory)
            {
                Debug.LogErrorFormat("StoryManager[{0}] : 程序尝试触发一段索引为'{1}'的剧情，但当前正在进行剧情中!", GetInstanceID(), startIndex);
                return;
            }
            Debug.LogFormat("StoryManager[{0}] : 开始索引为'{1}'的剧情", GetInstanceID(), startIndex);
            StartCoroutine(SS(story[startIndex]));
        }
        private IEnumerator SS(Dictionary<int, StoryDefine> define)
        {
            IsStory = true;
            storyView.gameObject.SetActive(true);
            yield return StartCoroutine(storyView.StartStory(define, this));
            storyView.gameObject.SetActive(false);
            IsStory = false;
            if (StoryEnd != null)
                StoryEnd.Invoke();
        }
    }
}
