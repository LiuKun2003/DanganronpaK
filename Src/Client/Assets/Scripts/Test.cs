using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Managers;

namespace Views
{
    public class Test : MonoBehaviour
    {
        public void TestMethod()
        {
            StoryManager.Instance.StoryStart(1);
        }
    }
}
