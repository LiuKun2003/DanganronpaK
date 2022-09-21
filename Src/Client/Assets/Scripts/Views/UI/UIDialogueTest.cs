using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace MyGame
{
    public class UIDialogueTest : MonoBehaviour
    {
        public Text context;

        public void StartDialog(string[] dia)
        {
            StartCoroutine(Dialog(dia));
        }
        private IEnumerator Dialog(string[] dia)
        {
            foreach (var item in dia)
            {
                context.text = item;
                yield return new WaitForSeconds(1f);
            }
        }
    }
}
