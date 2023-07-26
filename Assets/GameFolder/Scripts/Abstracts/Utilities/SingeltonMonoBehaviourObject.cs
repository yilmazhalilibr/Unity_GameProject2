using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UdemyProject2.Abstracts.Utilities
{
    public abstract class SingeltonMonoBehaviourObject<T> : MonoBehaviour where T : Component
    {
        public static T Instance { get; private set; }

        protected void SingletonThisObject(T entity)
        {
            if (Instance == null)
            {
                Instance = entity;
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }

        }



    }

}
