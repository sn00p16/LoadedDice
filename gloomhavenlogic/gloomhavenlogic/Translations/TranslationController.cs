using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Xml.Linq;

namespace gloomhavenlogic.Translations
{
    public sealed class TranslationController
    {
        private const string SentenceSpacing = " ";

        public TranslationController()
        {
            SupportedLanguages = new List<Language>();
            CurrentLanguage = Language.Undefined;
            Translations = new Dictionary<Language, Dictionary<string, string>>();
            DefaultLanguage = Language.English;
            TranslationsPath = AppContext.BaseDirectory + "..\\..\\data\\translations\\";

            LoadTranslations();
        }

        public List<Language> SupportedLanguages { get; private set; }
        public Language CurrentLanguage { get; private set; }

        private Dictionary<Language, Dictionary<string, string>> Translations { get; set; }
        private Language DefaultLanguage { get; set; }
        private string TranslationsPath { get; set; }

        public void SetLanguage(Language language)
        {
            if (!SupportedLanguages.Contains(language))
            {
                CurrentLanguage = DefaultLanguage;
                return;
            }

            CurrentLanguage = language;
        }

        public string GetTranslation(string label)
        {
            var latest_translation = label;

            // Get the translation from the language, or from the default language
            if (Translations[CurrentLanguage].ContainsKey(latest_translation))
                latest_translation = Translations[CurrentLanguage][latest_translation];
            else if (Translations[DefaultLanguage].ContainsKey(latest_translation))
                latest_translation = Translations[DefaultLanguage][latest_translation];

            // If we've found our way to the end, return the translation
            if (latest_translation == label)
                return latest_translation;

            return GetTranslation(latest_translation);
        }

        private void LoadTranslations()
        {
            var path = TranslationsPath + "languages.xml";
            var languages_xml = XDocument.Load(path);
            var language_node = (languages_xml.FirstNode as XElement).Element("Language");

            while (language_node != null)
            {
                LoadLanguage(language_node);
                language_node = language_node.NextNode as XElement;
            }

            CurrentLanguage = DefaultLanguage;
        }

        private void LoadLanguage(XElement node)
        {
            var language_enum = GetLanguageEnumFromString(node.Attribute("lang").Value.ToString());
            if (!SupportedLanguages.Contains(language_enum))
                SupportedLanguages.Add(language_enum);

            if (node.Attribute("default") != null && node.Attribute("default").Value.ToString() == "true")
                DefaultLanguage = language_enum;

            CurrentLanguage = language_enum;
            Translations.Add(language_enum, new Dictionary<string, string>());

            var file_node = node.FirstNode as XElement;
            while (file_node != null)
            {
                LoadTranslationFile(file_node);
                file_node = file_node.NextNode as XElement;
            }
        }

        private void LoadTranslationFile(XElement node)
        {
            var path = TranslationsPath + node.Attribute("filename").Value.ToString();
            var translation_xml = XDocument.Load(path);
            var translation_node = (translation_xml.FirstNode as XElement).Element("Translation");

            while (translation_node != null)
            {
                LoadTranslation(translation_node);
                translation_node = translation_node.NextNode as XElement;
            }
        }

        private void LoadTranslation(XElement node)
        {
            var translation_key = node.Attribute("key").Value.ToString();
            if (Translations[CurrentLanguage].ContainsKey(translation_key))
            {
                Debug.Fail("Translation key [" + translation_key + "] already exists in the dictionary");
                return;
            }

            var paragraph_node = node.Element("Paragraph");
            var story = "";
            while (paragraph_node != null)
            {
                story += LoadParagraph(paragraph_node);
                paragraph_node = paragraph_node.NextNode as XElement;

                story += "\r\n";
                if (paragraph_node != null)
                    story += "\r\n";
            }

            Translations[CurrentLanguage].Add(translation_key, story);
        }

        private string LoadParagraph(XElement node)
        {
            var paragraph = "";
            var sentence_node = node.FirstNode as XElement;
            while (sentence_node != null)
            {
                paragraph += sentence_node.Value;
                sentence_node = sentence_node.NextNode as XElement;

                if (sentence_node != null)
                    paragraph += SentenceSpacing;
            }

            return paragraph;
        }

        private Language GetLanguageEnumFromString(string language)
        {
            switch(language)
            {
                case "Chinese":
                    return Language.Chinese;
                case "English":
                    return Language.English;
                case "French":
                    return Language.French;
                case "German":
                    return Language.German;
                case "Japanese":
                    return Language.Japanese;
                case "Portuguese":
                    return Language.Portuguese;
                case "Russian":
                    return Language.Russian;
                case "Spanish":
                    return Language.Spanish;
                default:
                    return Language.Undefined;
            }
        }

        #region Singleton Implementation

        private static TranslationController instance = null;
        private static readonly object padlock = new object();

        public static TranslationController Instance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new TranslationController();
                    }
                    return instance;
                }
            }
        }

        #endregion
    }
}
