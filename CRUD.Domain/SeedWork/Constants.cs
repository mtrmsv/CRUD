using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD.Domain.SeedWork
{
    public class Constants
    {
        public static class MaxLengh
        {
            public const int Password = 15;
            public const int UserName = 10;
            public const int RoleName = 15;
        } 

        public static class MinLengh 
        {
            public const int Password = 8;
            public const int UserName = 5;
        }

        public static class RegulalExpression 
        {
            public const string Email = @"^[a-zA-Z0-9_.-]+@[a-zA-Z0-9_.-]+$";
            public const string Password = @"^[a-zA-Z0-9_]{8,20}$";

        }
    }
}
