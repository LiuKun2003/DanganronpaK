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
            #region 加载日志配置
            FileInfo file = new System.IO.FileInfo("log4net.config");//获取log4net配置文件
            GlobalContext.Properties["ApplicationLogPath"] = Path.Combine(file.Directory.FullName, "Log");//日志生成的路径
            GlobalContext.Properties["LogFileName"] = "log";//生成日志的文件名
            log4net.Config.XmlConfigurator.ConfigureAndWatch(file);//加载log4net配置文件
            #endregion
            #region 播放开场动画
            start_Vedio.gameObject.SetActive(true);
            start_Vedio.loopPointReached += EndReached;//监听动画是否播放完成
            isVideoDone = false;
            start_Vedio.Play();
            while (!isVideoDone)
            {
                if (Input.GetKeyUp(KeyCode.Escape))//按esc跳过
                    isVideoDone = true;
                yield return null;
            }
            start_Vedio.gameObject.SetActive(false);
            yield return new WaitForSeconds(0.5f);
            #endregion
            //初始化一些游戏配置
            SoundManager.Instance.PlayMusic("Gallery Music");//TODO:之后会把音乐名字改在配置中动态读取
        }

        private void EndReached(VideoPlayer vp)
        {
            isVideoDone = true;
        }
    }
}
