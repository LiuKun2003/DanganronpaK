using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Define
{
    public class StoryDefine
    {
        /// <summary>
        /// 内容文本
        /// </summary>
        public string Content { get; set; }
        /// <summary>
        /// 下一段内容的索引
        /// </summary>
        public int Next { get; set; }
        /// <summary>
        /// 标记当前内容的立绘显示
        /// </summary>
        public string CharacterMark { get; set; }
        /// <summary>
        /// 标记当前内容要伴随的特效
        /// </summary>
        public string Effects { get; set; }
    }
}
