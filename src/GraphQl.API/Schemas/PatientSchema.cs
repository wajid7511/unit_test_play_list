using System;

namespace GraphQl.API.Schemas;

public class PatientSchema
{
    [GraphQLName("id")]
    [GraphQLNonNullType]
    public int Id { get; set; }
    [GraphQLName("name")]
    [GraphQLNonNullType]
    public string Name { get; set; } = string.Empty;
    [GraphQLName("creationDateTime")]
    [GraphQLNonNullType]
    public DateTimeOffset CreationDateTime { get; set; }
}
