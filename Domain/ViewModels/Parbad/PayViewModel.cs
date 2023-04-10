using Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace ViewModels.Parbad
{
	public class PayViewModel : object
	{
		public PayViewModel() : base()
		{
		}

		[Display(Name = "Tracking number")]
		public long TrackingNumber { get; set; }

		[Display(Name = "Generate the Tracking number automatically?")]
		public bool GenerateTrackingNumberAutomatically { get; set; } = true;

		public decimal Amount { get; set; }

		[Display(Name = "Gateway")]
		public Gateways SelectedGateway { get; set; } = Gateways.ParbadVirtual;
	}
}
