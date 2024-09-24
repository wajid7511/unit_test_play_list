using System;

namespace GraphQl.API.Inputs;

public class PatientInput
{
    [GraphQLName("name")]
    public string Name { get; set; } = string.Empty;
}
