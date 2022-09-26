using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Define;
using Managers;

namespace Views
{
    public class UIStory : MonoBehaviour
    {
        public Text content;
        /// <summary>
        /// 开始一段剧情（此函数不应被手动调用，若想开始新的剧情，请调用StoryManager.StoryStart）
        /// </summary>
        public IEnumerator StartStory(Dictionary<int, StoryDefine> define, StoryManager manager)
        {
            StoryDefine currentDefine = define[1];
            bool isDone = false;
            while(currentDefine != null)
            {
                content.text = currentDefine.Content;
                while (!isDone)
                {
                    isDone = Input.GetMouseButtonDown(0);
                    yield return null;
                }
                if (currentDefine.Next != 0)
                    currentDefine = define[currentDefine.Next];
                else
                    currentDefine = null;
                isDone = false;
            }
        }
    }
}
