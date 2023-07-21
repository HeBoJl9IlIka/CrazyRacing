using System;
using UnityEngine;

namespace CrazyRacing.Model
{
    public abstract class Sdk : MonoBehaviour
    {
        public virtual bool IsMobile { get; protected set; }

        public Action Initialized;
        public event Action ShowedVideoAd;
        public event Action OpenedAd;
        public event Action ClosedInterstitialAd;
        public event Action ClosedVideoAd;
        public event Action CrashedInterstitialAd;
        public event Action CrashedVideoAd;

        public abstract void ShowInterstitialAd();
        public abstract void ShowVideoAd();

        public void ChangeLanguage()
        {
            ILanguage language = GetLanguage();

            if (language != null)
                Lean.Localization.LeanLocalization.SetCurrentLanguageAll(language.Value);
        }

        protected abstract void Init();
        protected abstract ILanguage GetLanguage();
        protected abstract void IdentifyDevice();

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
