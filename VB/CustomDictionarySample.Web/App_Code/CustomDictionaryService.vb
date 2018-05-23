Imports Microsoft.VisualBasic
Imports System.Linq
Imports System.ServiceModel.Activation

<AspNetCompatibilityRequirements(RequirementsMode := AspNetCompatibilityRequirementsMode.Allowed)> _
Public Class CustomDictionaryService
	Implements ICustomDictionaryService
	Private Const customDictionaryPath As String = "~/App_Data/Dictionaries/CustomWords.txt"

	#Region "ICustomDictionaryService Members"

	Public Function LoadCustomDictionary() As String() Implements ICustomDictionaryService.LoadCustomDictionary
		Dim path As String = System.Web.HttpContext.Current.Server.MapPath(customDictionaryPath)
		Return System.IO.File.ReadLines(path).ToArray()
	End Function

	Public Sub SaveCustomDictionary(ByVal words() As String) Implements ICustomDictionaryService.SaveCustomDictionary
		Dim path As String = System.Web.HttpContext.Current.Server.MapPath(customDictionaryPath)
		System.IO.File.WriteAllLines(path, words)
	End Sub

	#End Region
End Class
