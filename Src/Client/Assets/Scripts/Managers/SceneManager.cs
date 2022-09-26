using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System;

namespace Managers
{
    public class SceneManager : MonoSingleton<SceneManager>
    {
        /// <summary>
        /// 加载场景中的回调事件
        /// </summary>
        public event Action<float> onProgress;
        /// <summary>
        /// 场景加载完毕时的回调事件
        /// </summary>
        public event Action onSceneLoadDone;
        /// <summary>
        /// 启动一个协程加载指定场景，此操作是异步的
        /// </summary>
        /// <param name="index">要加载的场景在场景构建中的索引</param>
        public void LoadScene(int index)
        {
            int Count = UnityEngine.SceneManagement.SceneManager.sceneCountInBuildSettings;
            if (index >= Count)
            {
                Debug.LogErrorFormat("SceneManager[{0}] : 要加载的索引'{1}'超出最大范围'{2}'!", GetInstanceID(), index, Count);
                return;
            }
            Debug.LogFormat("SceneManager[{0}] : 开始加载索引为'{1}'的场景", GetInstanceID(), index);
            StartCoroutine(LoadLevel(index));
        }
        /// <summary>
        /// 启动一个协程加载指定场景，此操作是异步的
        /// </summary>
        /// <param name="name">要加载的场景名字</param>
        public void LoadScene(string name)
        {
            UnityEngine.SceneManagement.Scene loadScene = UnityEngine.SceneManagement.SceneManager.GetSceneByName(name);
            if (loadScene == null)
            {
                Debug.LogErrorFormat("SceneManager[{0}] : 要加载的场景名'{1}'不存在!", GetInstanceID(), name);
                return;
            }
            LoadScene(loadScene.buildIndex);
        }
        /// <summary>
        /// 启动一个协程加载场景构建中的下一个场景，此操作是异步的
        /// </summary>
        public void LoadNextScene()
        {
            LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex + 1);
        }
        private IEnumerator LoadLevel(int index)
        {
            AsyncOperation async = UnityEngine.SceneManagement.SceneManager.LoadSceneAsync(index);
            async.allowSceneActivation = true;
            async.completed += LevelLoadCompleted;
            while (!async.isDone)
            {
                if (onProgress != null)
                    onProgress(async.progress);
                yield return null;
            }
            Debug.LogFormat("SceneManager[{0}] : 索引为'{1}'的场景加载完毕", GetInstanceID(), index);
        }
        private void LevelLoadCompleted(AsyncOperation obj)
        {
            if (onProgress != null)
                onProgress(1f);
            if (onSceneLoadDone != null)
                onSceneLoadDone();
        }
    }
}