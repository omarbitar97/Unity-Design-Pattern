//-------------------------------------------------------------------------------------
//	SingletonStructure.cs
//-------------------------------------------------------------------------------------

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SingletonStructure : MonoBehaviour
{
    void Start()
    {
        var s1 = Singleton.Instance;
        var s2 = Singleton.Instance;

        if (s1 == s2)
        {
            Debug.Log("Objects are the same instance");
        }
    }
}

public class Singleton
{
    private static Singleton _instance;

    protected Singleton() { }

    public static Singleton Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new Singleton();
            }
            return _instance;
        }
    }
}