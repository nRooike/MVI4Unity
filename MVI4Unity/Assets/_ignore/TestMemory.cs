using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using System.IO.Compression;
public class TestMemory : MonoBehaviour
{
    // Start is called before the first frame update
    private static string datasStr = "qwedasdasdasdasdafafadasdasd";
    TestMemoryStream stream = new TestMemoryStream();
   
    void Start()
    {
       byte[] myByte= System.Text.Encoding.UTF8.GetBytes(datasStr);
        MemoryStream memory = new MemoryStream();
        var gz = new GZipStream(memory,CompressionMode.Compress);
        gz.Write(myByte,0,myByte.Length);
        gz.Close();
        Debug.Log("Test01:"+memory.GetBuffer());
        StartCoroutine(Test(memory));
    }
    IEnumerator Test(object data)
    {
        yield return new WaitForSeconds(5);
        System.GC.Collect();
        MemoryStream stream = data as MemoryStream;
        Debug.Log(stream.GetBuffer());
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}

public class TestMemoryStream : MonoBehaviour
{
    IEnumerator Test(object data)
    {
        yield return new WaitForSeconds(5);
        System.GC.Collect();
        MemoryStream stream = data as MemoryStream;
        Debug.Log(stream.GetBuffer());
    }
     public void TestMemory(object data)
    {
        StartCoroutine(Test(data));
    }

    public void TestMemory2(object data)
    { 
        MemoryStream stream=data as MemoryStream;
        Debug.Log(stream.GetBuffer());
    }
}
