using System.ComponentModel.DataAnnotations;

namespace DataLayer;
public enum TicketStepEnum
{
    [Display(Name = "رزرو")]
    Reserve = 0,
    [Display(Name = "خرید")]
    Buy = 1,
    [Display(Name = "استفاده از بلیط")]
    UseTicket = 2,
}
