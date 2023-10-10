namespace Game
{
    using System;
    using UnityEngine;

    public abstract class BaseSingleton<T> : MonoBehaviour where T : BaseSingleton<T>
    {
        public static T Instance { get; private set; }

        protected virtual void Awake()
        {
            if (Instance != null)
                throw new InvalidOperationException($"There can be only one instance of class {typeof(T)}");

            Instance = (T)this;
        }
    }
}