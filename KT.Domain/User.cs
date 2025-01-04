namespace KT.Domain
{
    public class User
    {     
        public int Id { get; set; }
        public long ICnumber { get; set; }
        public string CustomerName { get; set; }  
        public string MobileNumber { get; set; }
        public string EmailAddress { get; set; }
        public string Pin { get; set; }
        public bool IsEmailVerified { get; set; }
        public bool IsMobileVerified { get; set; }
        public DateTime CreatedAt { get; set; }
    }

   

}
