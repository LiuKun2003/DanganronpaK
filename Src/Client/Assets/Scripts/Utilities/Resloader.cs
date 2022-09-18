using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public static class Resloader
{
    /// <summary>
    /// 获取Resources文件夹下指定的资源
    /// </summary>
    /// <typeparam name="T">资源类型</typeparam>
    /// <param name="path">Resources文件夹下的资源路径</param>
    /// <returns></returns>
    public static T Load<T>(string path) where T : UnityEngine.Object
    {
        return Resources.Load<T>(path);
    }
}