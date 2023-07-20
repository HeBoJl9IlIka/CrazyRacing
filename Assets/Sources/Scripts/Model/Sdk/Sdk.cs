using System;
using UnityEngine;

namespace CrazyRacing.Model
{
    public abstract class Sdk : MonoBehaviour
    {
        public Action Initialized;
        public event Action ShowedVideoAd;
        public event Action OpenedAd;
        public event Action ClosedInterstitialAd;
        public event Action ClosedVideoAd;
        public event Action CrashedInterstitialAd;
        public event Action CrashedVideoAd;

        public abstract void ShowInterstitialAd();
        public abstract void ShowVideoAd();

        protected void OnRewarded()
        {
            ShowedVideoAd?.Invoke();
        }

        protected void OnOpenAd()
        {
            OpenedAd?.Invoke();
        }

        protected void OnCloseInterstitialAd(bool arg)
        {
            ClosedInterstitialAd?.Invoke();
        }
        
        protected void OnCloseVideoAd()
        {
            ClosedVideoAd?.Invoke();
        }

        protected void OnErrorInterstitialAd(string arg)
        {
            CrashedInterstitialAd?.Invoke();
        }

        protected void OnErrorVideoAd(string arg)
        {
            CrashedVideoAd?.Invoke();
        }
    }
}
