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
        /// 加载指定的DialoguesDefine
        /// </summary>
        /// <param name="name">DialoguesDefine的名字</param>
        /// <returns>一个以配置表中的Key为主键的Dictionary</returns>
        public Dictionary<int, DialoguesDefine> LoadDialogues(string name)
        {
            string json = File.ReadAllText(DataPath + name);
            return JsonConvert.DeserializeObject<Dictionary<int, DialoguesDefine>>(json);
        }
    }
}
