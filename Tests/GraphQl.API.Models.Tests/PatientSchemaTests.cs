namespace GraphQl.API.Models.Tests;

[TestClass]
public class PatientSchemaTests : BaseGraphqlSchemaTests
{
    public override object GetObj()
    {
        return new PatientSchema();
    }

    public override void AssertGraphQlName(Dictionary<string, string> graphQlNameDictionary)
    {
        Assert.AreEqual("id", graphQlNameDictionary[nameof(PatientSchema.Id)]);
        Assert.AreEqual("name", graphQlNameDictionary[nameof(PatientSchema.Name)]);
        Assert.AreEqual("creationDateTime", graphQlNameDictionary[nameof(PatientSchema.CreationDateTime)]);
    }
}
