using System;
using System.Collections.Generic;
using System.IO;
using Models;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Managers
{
    public class DataManager : Singleton<DataManager>
    {
        public const string DataPath = "Data/";

        public void Init()
        {
            
        }

        public Dictionary<int, DialoguesDefine> LoadDialogues(string name)
        {
            string json = File.ReadAllText(DataPath + name);
            return JsonConvert.DeserializeObject<Dictionary<int, DialoguesDefine>>(json);
        }
    }
}
