using Microsoft.Extensions.Options;

namespace Services.SMS
{
	public class SmsService : ISmsService
	{
		public SmsService(IOptions<ViewModels.Settings.KavenegarInfo> kavenegarInfo)
		{
			KavenegarInfo = kavenegarInfo.Value;
		}

		protected ViewModels.Settings.KavenegarInfo KavenegarInfo { get; }

		public async Task SendPublicSMS
			(string phoneNumber, string message)
		{
			try
			{
				var api =
					new Kavenegar.KavenegarApi(apikey: KavenegarInfo.ApiKey);

				var result =
					await api.Send(sender: KavenegarInfo.Sender, receptor: phoneNumber, message: message);
			}
			catch (Kavenegar.Core.Exceptions.ApiException ex)
			{
				// Logger
				throw new Exception(ex.Message);
			}
			catch (Kavenegar.Core.Exceptions.HttpException ex)
			{
				// Logger
				throw new Exception(ex.Message);
			}
		}

		public async Task SendLookupSMS
			(string phoneNumber, string templateName, string token1, string? token2 = "", string? token3 = "")
		{
			try
			{
				var api =
					new Kavenegar.KavenegarApi(apikey: KavenegarInfo.ApiKey);

				var result =
					await api.VerifyLookup(receptor: phoneNumber, token: token1, token2: token2, token3: token3, template: templateName);
			}
			catch (Kavenegar.Core.Exceptions.ApiException ex)
			{
				// Logger
				throw new Exception(ex.Message);
			}
			catch (Kavenegar.Core.Exceptions.HttpException ex)
			{
				// Logger
				throw new Exception(ex.Message);
			}
		}
	}
}
