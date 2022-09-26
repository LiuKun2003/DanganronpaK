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
        /// ��ʼһ�ξ��飨�˺�����Ӧ���ֶ����ã����뿪ʼ�µľ��飬�����StoryManager.StoryStart��
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
