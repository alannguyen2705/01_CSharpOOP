Card viettel = new();

Console.WriteLine($"Provider Name: {viettel.ProviderName}");
Console.WriteLine($"Price        : {viettel.Price}");
Console.WriteLine($"Serial number: {viettel.SerialNumber}");
Console.WriteLine($"Code         : {viettel.Code}");
Console.WriteLine($"Expired Date : {viettel.ExpirationDate}");
Console.WriteLine($"Description  : {viettel.Description}");
Console.WriteLine($"Is Valid     : {(viettel.IsValid() ? "valid" : "invalid")}");

class Card
{
	#region Fields
	private string serialNumber;
	private string code;
	#endregion

	#region Constructors
	public Card()
	{
		Console.WriteLine("constructor 1");
	}

	public Card(string providerName, decimal price)
	{
		Console.WriteLine("constructor 2");
		ProviderName = providerName;
		Price = price; 
	}

	public Card(string providerName, decimal price, string serialNumber)
	{
		Console.WriteLine("constructor 3");
		ProviderName = providerName;
		Price = price;
		SerialNumber= serialNumber;
	}
	#endregion

	#region Properties
	public string ProviderName { get; set; }
	public decimal Price { get; set; }
	public DateTime ExpirationDate { get; set; }
	public string Description { get; set; }
	public string SerialNumber
	{
		get => serialNumber;
		set
		{
			if (value is null)
				throw new ArgumentNullException("Serial Number's must be required");

			if (value is { Length: not 14})
				throw new InvalidDataException("Serial Number's length must be 14 digits");

			serialNumber = value;
		}
	}
	public string Code { 
		get => code;
		set
		{
			if (value is null)
				throw new ArgumentNullException("Code's length must be required");

			if (value is { Length: not 15 })
				throw new InvalidDataException("Code's length must be 15 digits");

			code = value;
		}
	}
	#endregion

	#region Methods
	public bool IsValid() => DateTime.Now <= ExpirationDate;
	#endregion
}