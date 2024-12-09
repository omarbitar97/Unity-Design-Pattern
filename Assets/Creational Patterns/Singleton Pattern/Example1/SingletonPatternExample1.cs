//-------------------------------------------------------------------------------------
//	SingletonPatternExample1.cs
//-------------------------------------------------------------------------------------

using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

//This real-world code demonstrates the Singleton pattern as a LoadBalancing object. Only a single instance (the singleton) of the class can be created 
//because servers may dynamically come on- or off-line and every request must go throught the one object that has knowledge about the state of the (web) farm.

namespace SingletonPatternExample1
{
    public class SingletonPatternExample1 : MonoBehaviour
    {
        void Start()
        {
            var balancer = LoadBalancer.Instance;

            for (int i = 0; i < 15; i++)
            {
                string server = balancer.Server;
                Debug.Log("Dispatch Request to: " + server);
            }
        }
    }

    public sealed class LoadBalancer
    {
        private static readonly object _syncLock = new object();
        private static LoadBalancer _instance;
        private readonly List<string> _servers = new List<string> { "ServerI", "ServerII", "ServerIII", "ServerIV", "ServerV" };
        private readonly System.Random _random = new System.Random();

        private LoadBalancer() { }

        public static LoadBalancer Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (_syncLock)
                    {
                        if (_instance == null)
                        {
                            _instance = new LoadBalancer();
                        }
                    }
                }
                return _instance;
            }
        }

        public string Server
        {
            get
            {
                int r = _random.Next(_servers.Count);
                return _servers[r];
            }
        }
    }
}
