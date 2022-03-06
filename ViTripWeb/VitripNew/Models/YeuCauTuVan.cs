namespace VitripNew.Models
{
    public class YeuCauTuVan
    {
        public int TypeId { get; set; }
        public string From { get; set; }
        public string To { get; set; }
        public int Adult { get; set; }
        public int Child { get; set; }
        public int Baby { get; set; }
        public DateTime Date { get; set; }
        public int Duration { get; set; }
        public decimal Budget { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public DateTime Birthday { get; set; }
        public string HotelLevel { get; set; }
        public string Note { get; set; }
        public bool ReceiveConsultByEmail { get; set; }
        public bool ReceiveNewsByEmail { get; set; }
    }
}
