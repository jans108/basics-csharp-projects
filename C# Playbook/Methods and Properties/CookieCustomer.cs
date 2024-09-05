namespace Pluralsight.CShPlaybook.MethodsProps;

public class CookieCustomer
{
	public int Id { get; } // must be > 0

	public string Name { get; } // must contain something
	
	public string? Notes { get; set; }

	public char NameFirstChar => Name[0];

	public CookieCustomer(int id, string name, string? notes=null)
	{
		ValidateName(name, nameof(name));

		ValidateId(id, nameof(id));

		Id = id;
		Name = name;
		Notes = notes;
	}

	private void ValidateName(string name, string paramName)
	{
		if (string.IsNullOrWhiteSpace(name))
			throw new ArgumentException("Customer name cannot be null or whitespace", paramName);
	}

	private void ValidateId(int id, string paramName)
	{
		if (id <= 0)
			throw new ArgumentException($"Customer ID must be higher than 0. Actual value was: {id}", paramName);
	}

	private ArgumentException BuildInvalidIdException(int value, string paramName)
	{
		throw new ArgumentException($"Customer ID must be higher than 0. Actual value was: {value}", paramName);
	}

	public override string ToString() => $"Customer Id={Id}, Name={Name}";


}
