# DXSpellChecker for Silverlight - How to persist custom dictionary content


<p>In Silverlight platform there is no direct method to persist <a href="http://documentation.devexpress.com/#WindowsForms/CustomDocument8581#custom"><u>Custom Dictionary</u></a> because this platform does not allow access to the operating system's file system. Instead, you should use <a href="http://www.silverlight.net/learn/graphics/file-and-local-data/isolated-storage-(silverlight-quickstart)"><u>Isolated Storage</u></a> to store data locally on the user's computer. However, there are a number of well know disadvantages with this approach (e.g. end-users may occasionally delete the Isolated Storage content). A safer and more flexible solution is to store critical data on the server side. To transfer data back and forth between client and server implement WCF service on the server side (ASP.NET application or web site) and consume it on the client side (Silverlight application). In our scenario the service should expose the interface with the following two methods: <strong>LoadCustomDictionary()</strong>, <strong>SaveCustomDictionary()</strong>. Please check the <a href="http://chakkaradeep.wordpress.com/2008/05/31/silverlight-and-wcf/"><u>Silverlight and WCF</u></a> web article to learn basics of using WCF in Silverlight.</p>

<br/>


