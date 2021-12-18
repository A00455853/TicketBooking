using Microsoft.AspNetCore.Mvc.Rendering;

namespace TicketBooking.Models
{
    public class MovieBookingDetails
    {
        public string MovieName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string CustomerName { get; set; }
        public string ExpiryDate { get; set; }
        public string CustomerMobile { get; set; }
        public string CustomerEmailAddress { get; set; }
        public string TheatreMovie { get; set; }
        public string CityName { get; set; }
        public string MovieImagePath { get; set; }
        public TimeSpan ShowTime { get; set; }
        public int MovieId { get; set; }
        public int TheatreId { get; set; }
        public int CityId { get; set; }
        public int ShowTimeId { get; set; }
        public string strYear { get; set; }
        public string strMonth { get; set; }
        public string strCreditCardType { get; set; }
        public string strTicketNumbers { get; set; }
        public string CreditCardNumber { get; set; }
        public string TheatreName { get; set; }
        
        public DateTime SelectedDateTime { get; set; }
        public IEnumerable<SelectListItem> CreditCardType
        {
            get
            {
                List<SelectListItem> creditCard = new List<SelectListItem>();
                creditCard.Add(new SelectListItem { Text = "MasterCard", Value = "1" });
                creditCard.Add(new SelectListItem { Text = "Visa", Value = "2" });
                creditCard.Add(new SelectListItem { Text = "American Express", Value = "3" });

                return creditCard;
            }
        }

        public IEnumerable<SelectListItem> ExpiryMonth
        {
            get
            {
                List<SelectListItem> expiryMonth = new List<SelectListItem>();
                expiryMonth.Add(new SelectListItem { Text = "1", Value = "1" });
                expiryMonth.Add(new SelectListItem { Text = "2", Value = "2" });
                expiryMonth.Add(new SelectListItem { Text = "3", Value = "3" });
                expiryMonth.Add(new SelectListItem { Text = "4", Value = "4" });
                expiryMonth.Add(new SelectListItem { Text = "5", Value = "5" });
                expiryMonth.Add(new SelectListItem { Text = "6", Value = "6" });
                expiryMonth.Add(new SelectListItem { Text = "7", Value = "7" });
                expiryMonth.Add(new SelectListItem { Text = "8", Value = "8" });
                expiryMonth.Add(new SelectListItem { Text = "9", Value = "9" });
                expiryMonth.Add(new SelectListItem { Text = "10", Value = "10" });
                expiryMonth.Add(new SelectListItem { Text = "11", Value = "11" });
                expiryMonth.Add(new SelectListItem { Text = "12", Value = "12" });


                return expiryMonth;
            }
        }

        public IEnumerable<SelectListItem> ExpiryYear
        {
            get
            {
                List<SelectListItem> expiryYear = new List<SelectListItem>();

                for (int i = 0; i < 3; i++)
                {
                    var year = DateTime.Now.AddYears(i).Year.ToString();

                    expiryYear.Add(new SelectListItem { Text = year, Value = year });
                }



                return expiryYear;
            }
        }
        public IEnumerable<TheatreBookedSeats> TheatreBookedSeats { get; set; }

        public int TicketCount
        {
            get
            {
                return 10;
            }
        }

        public int TicketPrice
        {
            get
            {
                return 150;
            }
        }

    }
}
