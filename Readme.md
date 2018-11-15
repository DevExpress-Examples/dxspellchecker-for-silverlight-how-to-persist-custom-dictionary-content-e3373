<!-- default file list -->
*Files to look at*:

* [CustomDictionaryService.cs](./CS/CustomDictionarySample.Web/App_Code/CustomDictionaryService.cs) (VB: [CustomDictionaryService.vb](./VB/CustomDictionarySample.Web/App_Code/CustomDictionaryService.vb))
* [ICustomDictionaryService.cs](./CS/CustomDictionarySample.Web/App_Code/ICustomDictionaryService.cs) (VB: [ICustomDictionaryService.vb](./VB/CustomDictionarySample.Web/App_Code/ICustomDictionaryService.vb))
* [CustomWords.txt](./CS/CustomDictionarySample.Web/App_Data/Dictionaries/CustomWords.txt) (VB: [CustomWords.txt](./VB/CustomDictionarySample.Web/App_Data/Dictionaries/CustomWords.txt))
* [CustomDictionarySampleTestPage.aspx](./CS/CustomDictionarySample.Web/CustomDictionarySampleTestPage.aspx) (VB: [CustomDictionarySampleTestPage.aspx](./VB/CustomDictionarySample.Web/CustomDictionarySampleTestPage.aspx))
* [CustomDictionaryService.svc](./CS/CustomDictionarySample.Web/CustomDictionaryService.svc) (VB: [CustomDictionaryService.svc](./VB/CustomDictionarySample.Web/CustomDictionaryService.svc))
* [Web.config](./CS/CustomDictionarySample.Web/Web.config) (VB: [Web.config](./VB/CustomDictionarySample.Web/Web.config))
* [MainPage.xaml](./CS/CustomDictionarySample/MainPage.xaml) (VB: [MainPage.xaml.vb](./VB/CustomDictionarySample/MainPage.xaml.vb))
* [MainPage.xaml.cs](./CS/CustomDictionarySample/MainPage.xaml.cs) (VB: [MainPage.xaml.vb](./VB/CustomDictionarySample/MainPage.xaml.vb))
<!-- default file list end -->
# DXSpellChecker for Silverlight - How to persist custom dictionary content


<p>In Silverlight platform there is no direct method to persist <a href="http://documentation.devexpress.com/#WindowsForms/CustomDocument8581#custom"><u>Custom Dictionary</u></a> because this platform does not allow access to the operating system's file system. Instead, you should use <a href="http://www.silverlight.net/learn/graphics/file-and-local-data/isolated-storage-(silverlight-quickstart)"><u>Isolated Storage</u></a> to store data locally on the user's computer. However, there are a number of well know disadvantages with this approach (e.g. end-users may occasionally delete the Isolated Storage content). A safer and more flexible solution is to store critical data on the server side. To transfer data back and forth between client and server implement WCF service on the server side (ASP.NET application or web site) and consume it on the client side (Silverlight application). In our scenario the service should expose the interface with the following two methods: <strong>LoadCustomDictionary()</strong>, <strong>SaveCustomDictionary()</strong>. Please check the <a href="http://chakkaradeep.wordpress.com/2008/05/31/silverlight-and-wcf/"><u>Silverlight and WCF</u></a> web article to learn basics of using WCF in Silverlight.</p>

<br/>


