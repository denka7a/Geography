using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geography.Data.Data.Constants
{
    public class DataConstants
    {
        public class User
        {
            public const int FullNameMinLength = 3;
            public const int FullNameMaxLength = 20;

            public const int PasswordMaxLength = 100;
            public const int PasswordMinLength = 6;
        }
        public class Hotel
        {
            public const int HotelNameMaxLength = 40;
            public const int HotelNameMinLength = 40;

            public const int HotelStarsMaxLength = 40;
            public const int HotelStarsMinLength = 40;

            public const int NatureNameMaxLength = 40;
            public const int NatureNameMinLength = 3;
        }
        public class Message
        {
            public const int WriterNameMaxLength = 40;
            public const int WriterNameMinLength = 3;

            public const int MessageMaxLength = 40;
            public const int MessageMinLength = 3;
        }
        public class Nature
        {
            public const int ObjectNameMaxLength = 40;
            public const int ObjectNameMinLength = 3;

            public const int InformationMaxLength = 300;
            public const int InformationMinLength = 3;

            public const int TypeMaxLength = 40;
            public const int TypeMinLength = 3;

        }
        public class Souvenir
        {
            public const int SouvenirNameMaxLength = 40;
            public const int SouvenirNameMinLength = 3;

        }
    }
}
