using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Define
{
    public class DialoguesDefine
    {
        /// <summary>
        /// 对话内容
        /// </summary>
        public string DialogueContent { get; set; }
        /// <summary>
        /// 下一句对话的索引
        /// </summary>
        public int Next { get; set; }
        /// <summary>
        /// 标记当前对话的立绘显示
        /// </summary>
        public string CharacterMark { get; set; }
        /// <summary>
        /// 标记当前对话要伴随的特效
        /// </summary>
        public string Effects { get; set; }
    }
}
