namespace Server.Areas.Admin.Infrastructure.Messages
{
	public enum MessageType : byte
	{
		PageError,
		PageWarning,
		PageSuccess,

		ToastError,
		ToastWarning,
		ToastSuccess,
	}
}
