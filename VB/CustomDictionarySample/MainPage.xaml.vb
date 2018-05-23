Imports Microsoft.VisualBasic
Imports System.Collections.ObjectModel
Imports System.Globalization
Imports System.Windows.Controls
Imports CustomDictionarySample.CustomDictionaryServiceReference
Imports DevExpress.Xpf.SpellChecker
Imports DevExpress.XtraSpellChecker
Imports System.Collections

Namespace CustomDictionarySample
    Partial Public Class MainPage
        Inherits UserControl
        Private spellCheker As SpellChecker
        Private serviceProxy As CustomDictionaryServiceClient

        Public Sub New()
            InitializeComponent()

            spellCheker = New SpellChecker()
            serviceProxy = New CustomDictionaryServiceClient()

            AddHandler serviceProxy.LoadCustomDictionaryCompleted, (Function(s, e) LoadCustomDictionaryCompleted(s, e))

            serviceProxy.LoadCustomDictionaryAsync()

            AddHandler spellCheker.WordAdded, (Function(s, e) WordAdded(s, e))
        End Sub

        Private Function LoadCustomDictionaryCompleted(ByVal s As Object, ByVal e As LoadCustomDictionaryCompletedEventArgs) As Boolean
            Dim customDictionary As New SpellCheckerCustomDictionary()
            customDictionary.AddWords(e.Result)
            customDictionary.Culture = New CultureInfo("en-US")
            spellCheker.Dictionaries.Add(customDictionary)
            spellCheker.Culture = customDictionary.Culture
            Return True
        End Function

        Private Function WordAdded(ByVal s As Object, ByVal e As WordAddedEventArgs) As Boolean
            Dim customDictionary As SpellCheckerCustomDictionary = CType(spellCheker.Dictionaries(0), SpellCheckerCustomDictionary)
            Dim words As New ObservableCollection(Of String)()
            For i As Integer = 0 To customDictionary.WordCount - 1
                words.Add(customDictionary(i))
            Next i
            serviceProxy.SaveCustomDictionaryAsync(words)
            Return True
        End Function

        Private Sub btnCheck_Click(ByVal sender As Object, ByVal e As System.Windows.RoutedEventArgs)
            spellCheker.Check(tbEditor)
        End Sub
    End Class
End Namespace
