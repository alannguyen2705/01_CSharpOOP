
using System.ComponentModel.DataAnnotations;

Card viettel = new();
viettel.SetProviderName("Viettel");
viettel.SetPrice(100_000m);
viettel.SetSerialNumber("10234567895463");
viettel.SetCode("012345678012304");
viettel.SetExpirationDate(new(2024, 12, 31));
viettel.SetDescription($"press toup: *100*code");

Console.WriteLine($"Provider name: {viettel.GetProviderName()}");
Console.WriteLine($"Price: {viettel.GetPrice()}");
Console.WriteLine($"Serial Number: {viettel.GetSerialNumber()}");
Console.WriteLine($"Code Number: {viettel.GetCode()}");
Console.WriteLine($"Expired Date: {viettel.GetExpirationDate()}");
Console.WriteLine($"Description: {viettel.GetDescription()}");
Console.WriteLine($"Is valid: {(viettel.isValid() ? "valid" : "invalid")}");

class Card
{
    #region Fields
    private string providerName;
    private decimal price;
    private string serialNumber;
    private string code;
    private DateTime expirationDate;
    private string description;
    #endregion

    #region Methods
    public string GetProviderName() => providerName;
    public void SetProviderName(string providerName) => this.providerName = providerName;
    public decimal GetPrice() => price;
    public void SetPrice(decimal price) => this.price = price;
    public string GetSerialNumber() => serialNumber;
    public void SetSerialNumber(string serialNumber)
    {
        if (serialNumber == null)
            throw new ArgumentNullException(nameof(serialNumber));
        if (serialNumber is { Length: not 14 })
            throw new InvalidDataException("Serial number's must be 14 digits");
        this.serialNumber = serialNumber;
    }
    public string GetCode() => code;
    public void SetCode(string code)
    {
        if (code == null)
            throw new ArgumentException(nameof(code));
        if (code is { Length: not 15 })
            throw new InvalidDataException("Code number's must be 15 digits");
        this.code = code;
    }
    public DateTime GetExpirationDate() => expirationDate;
    public void SetExpirationDate(DateTime expirationDate) => this.expirationDate = expirationDate;
    public string GetDescription() => description;
    public void SetDescription(string description) => this.description = description;
    public bool isValid() => DateTime.Now <= expirationDate;

    #endregion
}