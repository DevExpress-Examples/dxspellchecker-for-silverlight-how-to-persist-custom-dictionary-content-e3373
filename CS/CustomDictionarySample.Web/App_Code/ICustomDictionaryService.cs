using System.ServiceModel;

[ServiceContract]
public interface ICustomDictionaryService {
    [OperationContract]
    string[] LoadCustomDictionary();

    [OperationContract]
    void SaveCustomDictionary(string[] words);
}
