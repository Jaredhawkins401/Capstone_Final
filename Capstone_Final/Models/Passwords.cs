using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime;
using System.Web;

namespace Capstone_Final.Models
{
    public class Passwords
    {
        public string Password { get; private set; }
        public int Length { get; private set; }
        public int TotalNumbers { get; private set; }
        public bool ContainsNumbers { get { return TotalNumbers > 0; } }
        public int TotalUppers { get; private set; }
        public bool ContainsUppers { get { return TotalUppers > 0; } }
        public int TotalLowers { get; private set; }
        public bool ContainsLowers { get { return TotalLowers > 0; } }
        public int TotalSpecials { get; private set; }
        public bool ContainsSpecials { get { return TotalSpecials > 0; } }
        public string Errors { get; private set; }

        public Passwords(string password)
        {
            Password = password.Trim();
            Length = password.Length;
            foreach (var c in Password)
            {
                int charCode = (int)c;
                if (charCode >= 48 && charCode <= 57)
                    TotalNumbers++;
                else if (charCode >= 65 && charCode <= 90)
                    TotalUppers++;
                else if (charCode >= 97 && charCode <= 122)
                    TotalLowers++;
                else
                    TotalSpecials++;
   
            }
        }
        public bool StrongEnough()
        {
            // length 
            if (Length < 8)
            {
                Errors = "\n ERROR: Password needs to be at least 8 characters.";
                return false;
            }
            // upper and lower
            if (!ContainsLowers && !ContainsUppers)
            {
                Errors = "\n ERROR: Password needs to contain both upper and lower case characters.";
                return false;
            }
            // special character
            if (TotalSpecials < 1)
            {
                Errors = "\n ERROR: Password needs to have a special character (!,?,#,%...).";
                return false;
            }
            // Min upper case chars requirement
            if (TotalUppers < 1)
            {
                Errors = "\n ERROR: Password needs to have at least 1 uppercase.";
                return false;
            }

            if (TotalNumbers < 1)
            {
                Errors = "\n ERROR: Password needs to have at least 1 number";
                return false;
            }

            return true;
        }
    }
}
