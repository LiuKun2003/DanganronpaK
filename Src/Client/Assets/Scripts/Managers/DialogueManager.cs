using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Define;

namespace Managers
{
    public class DialogueManager : MonoSingleton<DialogueManager>
    {
        private Dictionary<int, DialoguesDefine> Dialogue;

        /// <summary>
        /// 对话结束时的回调函数
        /// </summary>
        public event Action DialogueEnd;
        /// <summary>
        /// 获取一个值，此值指示了是否正在对话中
        /// </summary>
        public bool IsDialogue { get; private set; }
        /// <summary>
        /// 获取或设置一个值，此值指示了对话是否自动播放
        /// </summary>
        public bool IsAuto { get; set; }
        /// <summary>
        /// 获取或设置一个值，此值指示了对话自动播放时会等待的时间（以秒为单位）
        /// </summary>
        public float WaitTimeForAuto { get; set; }
        /// <summary>
        /// 加载所需要的配置文件，所有的对话都会基于最后一次读取的配置
        /// </summary>
        /// <param name="name"></param>
        public void LoadDialogues(string name)
        {
            Dialogue = DataManager.Instance.LoadDialogues(name);
        }
        /// <summary>
        /// 以startIndex为索引，开始一段对话
        /// </summary>
        /// <param name="startIndex">开始索引</param>
        public void StartDialogue(int startIndex)
        {
            //开始对话
            //暂未实现
            //结束
            if (DialogueEnd != null)
                DialogueEnd.Invoke();
        }
    }
}
