using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GSE
{
    [Serializable]
    public class AssetServiceConfig
    {
        [Serializable]
        public class PrefabList
        {
            public string category;
            public List<GameObject> prefabs; 
        }
        [Serializable]
        public class DataList
        {
            public string category;
            public List<ScriptableObject> datas; 
        }
        
        public List<PrefabList> prefabs; 
        public List<DataList> datas; 

    }
    
    public class AssetService : GameService
    {
        private AssetServiceConfig config;
        
        public AssetService(AssetServiceConfig config)
        {
            this.config = config;
        }
        
        public GameObject GetPrefab(string name)
        {
            for (int i = 0; i < config.prefabs.Count; i++)
            {
                for (int k = 0; k < config.prefabs[i].prefabs.Count; k++)
                {
                    if (config.prefabs[i].prefabs[k].name == name)
                    {
                        return config.prefabs[i].prefabs[k];
                    }
                }
            }

            Debug.LogError($"Could not find prefab with name '{name}'");
            return null;
        }
        
        public GameObject GetPrefab(Type type)
        {
            for (int i = 0; i < config.prefabs.Count; i++)
            {
                for (int k = 0; k < config.prefabs[i].prefabs.Count; k++)
                {
                    if (config.prefabs[i].prefabs[k].GetComponent(type) != null)
                    {
                        return config.prefabs[i].prefabs[k];
                    }
                }
            }

            Debug.LogError($"Could not find prefab of type '{type}'");
            return null;
        }

        public T GetPrefab<T>() where T : MonoBehaviour
        {
            for (int i = 0; i < config.prefabs.Count; i++)
            {
                for (int k = 0; k < config.prefabs[i].prefabs.Count; k++)
                {
                    var result = config.prefabs[i].prefabs[k].GetComponent<T>();
                    if (result != null)
                    {
                        return result;
                    }
                }
            }

            Debug.LogError($"Could not find prefab of type '{typeof(T).Name}'");
            return null;
        }
        
        public T GetPrefab<T>(string name) where T : MonoBehaviour
        {
            for (int i = 0; i < config.prefabs.Count; i++)
            {
                for (int k = 0; k < config.prefabs[i].prefabs.Count; k++)
                {
                    var result = config.prefabs[i].prefabs[k].GetComponent<T>();
                    if (result != null && result.name == name)
                    {
                        return result;
                    }
                }
            }

            Debug.LogError($"Could not find prefab of type '{typeof(T).Name}'");
            return null;
        }
        
        public ScriptableObject GetData(string name)
        {
            for (int i = 0; i < config.datas.Count; i++)
            {
                for (int k = 0; k < config.datas[i].datas.Count; k++)
                {
                    if (config.datas[i].datas[k].name == name)
                    {
                        return config.datas[i].datas[k];
                    }
                }
            }

            Debug.LogError($"Could not find data with name '{name}'");
            return null;
        }
        
        public T GetData<T>(string name) where T : ScriptableObject
        {
            return GetData(name) as T;
        }
    }

}