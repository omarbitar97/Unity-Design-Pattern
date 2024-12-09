//-------------------------------------------------------------------------------------
//	SingletonPatternExample3.cs
//-------------------------------------------------------------------------------------

using UnityEngine;
using System.Collections;

namespace SingletonPatternExample3
{
    public class SingletonPatternExample3 : MonoBehaviour
    {
        void Start()
        {
            SingletonA.Instance.DoSomething();
            SingletonB.Instance.DoSomething();
        }
    }

    public abstract class Singleton<T> where T : class, new()
    {
        private static readonly object _syncLock = new object();
        private static T _instance;

        public static T Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (_syncLock)
                    {
                        if (_instance == null)
                        {
                            _instance = new T();
                        }
                    }
                }
                return _instance;
            }
        }
    }

    public class SingletonA : Singleton<SingletonA>
    {
        public void DoSomething()
        {
            Debug.Log("SingletonA: DoSomething!");
        }
    }

    public class SingletonB : Singleton<SingletonB>
    {
        public void DoSomething()
        {
            Debug.Log("SingletonB: DoSomething!");
        }
    }
}