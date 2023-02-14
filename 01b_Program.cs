Card viettel = new();
viettel.ProviderName = "Viettel";
viettel.Price = 100_000m;
viettel.SerialNumber = "10234567853695";
viettel.Code = "010234567853695";
viettel.ExpirationDate = new(2022, 12, 3);
viettel.Description = "Press to upto: *100*code#";

Console.WriteLine($"Provider Name: {viettel.ProviderName}");
Console.WriteLine($"Price	     : {viettel.Price}");
Console.WriteLine($"Serial Number: {viettel.SerialNumber}");
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

	#region Auto-Implemented Properties
	public string ProviderName { get; set; }
	public decimal Price { get; set; }
	public DateTime ExpirationDate { get; set; }
	public string Description { get; set; }
	public string SerialNumber { 
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
				throw new ArgumentNullException("Code's must be required");
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