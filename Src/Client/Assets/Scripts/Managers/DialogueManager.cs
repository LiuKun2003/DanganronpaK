using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace Managers
{
    public class DialogueManager : Singleton<DialogueManager>
    {
        public Dictionary<int, DialoguesDefine> Dialogue { private set; get; }

        public void LoadDialogues(string name)
        {
            Dialogue = DataManager.Instance.LoadDialogues(name);
        }
        public string[] GetDialogue(int startIndex)
        {
            if (!Dialogue.ContainsKey(startIndex)) return Array.Empty<string>();
            List<string> dia = new List<string>();
            DialoguesDefine current = Dialogue[startIndex];
            dia.Add(current.Dialogue);
            while(current.Next != 0)
            {
                current = Dialogue[current.Next];
                dia.Add(current.Dialogue);
            }
            return dia.ToArray();
        }
    }
}
