using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Managers
{
    public class SceneManager : MonoSingleton<SceneManager>
    {
        /// <summary>
        /// 加载场景中的回调事件
        /// </summary>
        public UnityAction<float> onProgress = null;
        /// <summary>
        /// 场景加载完毕时的回调事件
        /// </summary>
        public UnityAction onSceneLoadDone = null;
        /// <summary>
        /// 启动一个协程加载场景，此操作是异步的
        /// </summary>
        /// <param name="name">要加载的场景名字</param>
        public void LoadScene(string name)
        {
            UnityEngine.SceneManagement.Scene loadScene = UnityEngine.SceneManagement.SceneManager.GetSceneByName(name);
            StartCoroutine(LoadLevel(loadScene.buildIndex));
        }
        /// <summary>
        /// 启动一个协程加载场景，此操作是异步的
        /// </summary>
        /// <param name="index">要加载的场景在场景构建中的索引</param>
        public void LoadScene(int index)
        {
            StartCoroutine(LoadLevel(index));
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