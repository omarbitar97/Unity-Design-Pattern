//-------------------------------------------------------------------------------------
//	SingletonPatternExample2.cs
//-------------------------------------------------------------------------------------

using UnityEngine;
using System.Collections;

namespace SingletonPatternExample2
{
    public class SingletonPatternExample2 : MonoBehaviour
    {
        void Start()
        {
            RenderManager.Instance.Show();
        }

        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                RenderManager.Instance.Show();
            }
        }
    }

    public sealed class RenderManager
    {
        private static RenderManager _instance;

        private RenderManager() { }

        public static RenderManager Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new RenderManager();
                }
                return _instance;
            }
        }

        public void Show()
        {
            Debug.Log("RenderManager is a Singleton!");
        }
    }
}