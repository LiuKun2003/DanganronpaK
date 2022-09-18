using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using log4net;
using UnityEngine.Video;

namespace Managers
{
    public class LoadingManager : MonoBehaviour
    {
        public VideoPlayer start_Vedio;
        private bool isVideoDone;
        private IEnumerator Start()
        {
            #region ������־����
            FileInfo file = new System.IO.FileInfo("log4net.config");//��ȡlog4net�����ļ�
            GlobalContext.Properties["ApplicationLogPath"] = Path.Combine(file.Directory.FullName, "Log");//��־���ɵ�·��
            GlobalContext.Properties["LogFileName"] = "log";//������־���ļ���
            log4net.Config.XmlConfigurator.ConfigureAndWatch(file);//����log4net�����ļ�
            #endregion
            #region ���ſ�������
            start_Vedio.gameObject.SetActive(true);
            start_Vedio.loopPointReached += EndReached;//���������Ƿ񲥷����
            isVideoDone = false;
            start_Vedio.Play();
            while (!isVideoDone)
            {
                if (Input.GetKeyUp(KeyCode.Escape))//��esc����
                    isVideoDone = true;
                yield return null;
            }
            start_Vedio.gameObject.SetActive(false);
            yield return new WaitForSeconds(0.5f);
            #endregion
            //��ʼ��һЩ��Ϸ����
            SoundManager.Instance.PlayMusic("Gallery Music");//TODO:֮�����������ָ��������ж�̬��ȡ
        }

        private void EndReached(VideoPlayer vp)
        {
            isVideoDone = true;
        }
    }
}
