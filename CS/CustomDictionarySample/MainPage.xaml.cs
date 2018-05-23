using System.Collections.ObjectModel;
using System.Globalization;
using System.Windows.Controls;
using CustomDictionarySample.CustomDictionaryServiceReference;
using DevExpress.Xpf.SpellChecker;
using DevExpress.XtraSpellChecker;

namespace CustomDictionarySample {
    public partial class MainPage : UserControl {
        private SpellChecker spellCheker;
        private CustomDictionaryServiceClient serviceProxy;
        
        public MainPage() {
            InitializeComponent();

            spellCheker = new SpellChecker();
            serviceProxy = new CustomDictionaryServiceClient();

            serviceProxy.LoadCustomDictionaryCompleted += ((s, e) => {
                SpellCheckerCustomDictionary customDictionary = new SpellCheckerCustomDictionary();
                customDictionary.AddWords(e.Result);
                customDictionary.Culture = new CultureInfo("en-US");
                spellCheker.Dictionaries.Add(customDictionary);
                spellCheker.Culture = customDictionary.Culture;
            });

            serviceProxy.LoadCustomDictionaryAsync();

            spellCheker.WordAdded += ((s, e) => {
                SpellCheckerCustomDictionary customDictionary = (SpellCheckerCustomDictionary)spellCheker.Dictionaries[0];
                ObservableCollection<string> words = new ObservableCollection<string>();

                for (int i = 0; i < customDictionary.WordCount; i++) {
                    words.Add(customDictionary[i]);
                }

                serviceProxy.SaveCustomDictionaryAsync(words);
            });
        }

        private void btnCheck_Click(object sender, System.Windows.RoutedEventArgs e) {
            spellCheker.Check(tbEditor);
        }
    }
}
