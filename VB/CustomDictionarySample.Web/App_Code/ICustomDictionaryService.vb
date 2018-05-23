Imports Microsoft.VisualBasic
Imports System.ServiceModel

<ServiceContract> _
Public Interface ICustomDictionaryService
	<OperationContract> _
	Function LoadCustomDictionary() As String()

	<OperationContract> _
	Sub SaveCustomDictionary(ByVal words() As String)
End Interface
