using Agava.YandexGames;
using System.Collections;

#pragma warning disable CS0162 // Обнаружен недостижимый код

namespace CrazyRacing.Model
{
    public class YandexSdk : Sdk
    {
        private IEnumerator Start()
        {
#if !UNITY_WEBGL || UNITY_EDITOR
            Init();
            yield break;
#endif

            yield return YandexGamesSdk.Initialize(Init);
        }

        public override void ShowInterstitialAd()
        {
            InterstitialAd.Show(OnOpenAd, OnCloseInterstitialAd, OnErrorInterstitialAd);
        }

        public override void ShowVideoAd()
        {
            VideoAd.Show(OnOpenAd, OnRewarded, OnCloseVideoAd, OnErrorInterstitialAd);
        }

        private void Init()
        {
            ChangeLanguage();
            Initialized?.Invoke();
        }

        private void ChangeLanguage()
        {
#if !UNITY_WEBGL || UNITY_EDITOR
            return;
#endif

            string languageCode = YandexGamesSdk.Environment.i18n.lang;
            LanguageFactory languageFactory = new LanguageFactory();
            ILanguage language = languageFactory.GetLanguage(languageCode);

            if (language != null)
                Lean.Localization.LeanLocalization.SetCurrentLanguageAll(language.Value);
        }
    }
}
