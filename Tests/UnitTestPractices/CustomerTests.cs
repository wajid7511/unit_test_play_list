namespace UnitTestPractices;

[TestClass]
public class CustomerTests
{
    [TestMethod]
    public void Verify_Default_Constructor()
    {
        //Arrange
        int id = 0;
        string name = "";

        //Act
        Customer customer = new Customer();

        //Assert
        Assert.AreEqual(id, customer.Id);
        Assert.IsInstanceOfType(customer.Id, typeof(int));
        Assert.AreEqual(name, customer.Name);
        Assert.IsInstanceOfType(customer.Name, typeof(string));
    }
    [TestMethod]
    public void Verify_Argument_Constructor()
    {
        //Arrange
        int expectedId = 2;
        string expectedName = "Ali";

        //Act
        Customer customer = new Customer(expectedId, expectedName);

        //Assert
        Assert.AreEqual(expectedId, customer.Id);
        Assert.AreEqual(expectedName, customer.Name);
    }
    [TestMethod]
    public void Verify_ToString()
    {
        //Arrange
        int expectedId = 3;
        string expectedName = "Ali 3";
        string expectedToString = $"Id {expectedId} Name : {expectedName}";

        Customer customer = new Customer(expectedId, expectedName);

        //Act
        var result = customer.ToString();
        //Assert
        Assert.AreEqual(expectedToString, result);
    }
    [TestMethod]
    public void Check_Is_Type_Of_ICustomer()
    {
        //Arrange

        //Act
        var result = new Customer();

        //Assert
        Assert.IsInstanceOfType(result, typeof(ICustomer));
    }
}