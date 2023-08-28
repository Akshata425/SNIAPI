namespace SNIAPI.Helpers.Enums
{
    public class Enums
    {
       public enum UserRoles
        {
            Student =1,
            Admin = 2,
            Institute = 3,
            Faculty = 4,
            Sponsorer = 5,
            Scholarship = 6,
            ChannelPartner = 7,
        }
        public enum UserRole
        {
            Cet = 1,
            Neet = 2,
            Jee = 3            
        }

        public  enum LoginAs
        {
            Student = 1,
            Admin = 2,
            Institute = 3,
            Faculty = 4,
            Sponsorer = 5,
            Scholarship = 6,
            ChannelPartner = 7
        }
        
        public enum PaymentFor
        {
            OfflineAssessment =1,
            BuyingCourse = 2
        }
    }
}