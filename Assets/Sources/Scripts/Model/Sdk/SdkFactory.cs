using System;
using UnityEngine;

namespace CrazyRacing.Model
{
    public static class SdkFactory
    {
        public static Sdk Sdk { get; private set; }

        public static event Action Initialized;

        public static void Init(Sdk[] sdks)
        {
#if YANDEXSDK
            foreach (Sdk sdk in sdks)
            {
                if (sdk is YandexSdk)
                    Sdk = MonoBehaviour.Instantiate(sdk);
            }
#endif

            Sdk.Initialized += OnInitialized;
            MonoBehaviour.DontDestroyOnLoad(Sdk);
        }

        public static void Unsubscribe()
        {
            Sdk.Initialized -= OnInitialized;
        }

        private static void OnInitialized()
        {
            Initialized?.Invoke();
        }
    }
}
