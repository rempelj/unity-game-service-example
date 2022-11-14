using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GSE
{
    public class ServiceLocator
    {
        private Dictionary<string, GameService> services = new Dictionary<string, GameService>();

        public T Get<T>() where T : GameService
        {
            string key = typeof(T).Name;
            if (!services.ContainsKey(key))
            {
                Debug.LogError($"{key} not registered with {GetType().Name}");
                return default;
            }

            return (T)services[key];
        }
        
        public bool IsRegistered<T>() where T : GameService
        {
            string key = typeof(T).Name;
            return services.ContainsKey(key);
        }
        
        public int CountRegisteredServices()
        {
            return services.Count;
        }
            
        public void Register<T>(T service) where T : GameService
        {
            string key = typeof(T).Name;
            if (services.ContainsKey(key))
            {
                Debug.LogError($"Attempted to register service of type {key} which is already registered with the {GetType().Name}.");
                return;
            }

            services.Add(key, service);
        }
            
        public void Unregister<T>() where T : GameService
        {
            string key = typeof(T).Name;
            if (!services.ContainsKey(key))
            {
                Debug.LogError($"Attempted to unregister service of type {key} which is not registered with the {GetType().Name}.");
                return;
            }

            services.Remove(key);
        }
            
    }
}
