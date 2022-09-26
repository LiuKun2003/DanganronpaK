using System;
using System.Collections.Generic;
using System.IO;
using Define;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Managers
{
    public class DataManager : Singleton<DataManager>
    {
        private const string DataPath = "Data/";

        public void Init()
        {
            
        }
        /// <summary>
        /// 加载指定的StoryDefine（此函数不应被手动调用，若想加载新的StoryDefine，请调用StoryManager.LoadStoryDefine）
        /// </summary>
        /// <param name="name">StoryDefine的文件名（带后缀）</param>
        public Dictionary<int, Dictionary<int, StoryDefine>> LoadStoryDefine(string name)
        {
            string json = File.ReadAllText(DataPath + name);
            return JsonConvert.DeserializeObject<Dictionary<int, Dictionary<int, StoryDefine>>>(json);
        }
    }
}
