namespace API
{

   public class Customer
   {
      public int Id { get; set; }
      public string FirstName { get; set; }
      public string LastName { get; set; }
      public DateTime BirthDate { get; set; } 
      public string StreetName { get; set; }
      public int StreetNumber { get; set; }
      public int ZipCode { get; set; }
      public string City { get; set; }
      public string? Country { get; set; }
      
   }
}
