using System.Linq;

namespace CrazyRacing.Model
{
    public interface ILanguage
    {
        public string Value { get; }
        public string Code { get; }
    }

    public class Russian : ILanguage
    {
        public string Value => Config.RussianLanguage;
        public string Code => Config.RussianCode;
    }

    public class English : ILanguage
    {
        public string Value => Config.EnglishLanguage;
        public string Code => Config.EnglishCode;
    }

    public class Turkish : ILanguage
    {
        public string Value => Config.TurkishLanguage;
        public string Code => Config.TurkishCode;
    }

    public class LanguageFactory
    {
        private readonly ILanguage[] _languages;

        public LanguageFactory()
        {
            _languages = new ILanguage[] 
            {
                new Russian(),
                new English(),
                new Turkish()
            };
        }

        public ILanguage GetLanguage(string languageCode)
        {
            return _languages.FirstOrDefault(language => language.Code == languageCode);
        }
    }
}
