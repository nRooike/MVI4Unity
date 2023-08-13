using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Reflection;
using System.Text;
using UnityEngine;

public class test : MonoBehaviour
{
    delegate void TestDelegate();
    private void Start()
    {
       Delegate my= Delegate.CreateDelegate(typeof(TestDelegate), typeof(MyTest).GetMethod("TestStatci"));
        my.DynamicInvoke();
    }
}

public class MyTest
{
    public static void TestStatci()
    {
        Debug.Log("I am a static method");
    }

    public void Test()
    {
        Debug.Log("I am a common mehod");
    }
}