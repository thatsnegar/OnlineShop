namespace Services.SMS
{
	public interface ISmsService
	{
		Task SendPublicSMS(string phoneNumber, string message);

		Task SendLookupSMS(string phoneNumber, string templateName, string token1, string? token2 = "", string? token3 = "");
	}
}
