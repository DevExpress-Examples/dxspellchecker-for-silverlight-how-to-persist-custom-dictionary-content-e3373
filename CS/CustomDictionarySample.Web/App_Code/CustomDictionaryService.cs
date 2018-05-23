using System.Linq;
using System.ServiceModel.Activation;

[AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
public class CustomDictionaryService : ICustomDictionaryService {
    private const string customDictionaryPath = "~/App_Data/Dictionaries/CustomWords.txt";

    #region ICustomDictionaryService Members

    public string[] LoadCustomDictionary() {
        string path = System.Web.HttpContext.Current.Server.MapPath(customDictionaryPath);
        return System.IO.File.ReadLines(path).ToArray();
    }

    public void SaveCustomDictionary(string[] words) {
        string path = System.Web.HttpContext.Current.Server.MapPath(customDictionaryPath);
        System.IO.File.WriteAllLines(path, words);
    }

    #endregion
}
