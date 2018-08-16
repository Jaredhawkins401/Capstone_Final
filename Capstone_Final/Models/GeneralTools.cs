using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace Capstone_Final.Models
{
    public class GeneralTools
    {
        public static void Pause()
        {
            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
        }

        public static bool NotEmpty(int temp)
        {
            bool result = false;

            if (temp > 0)
            {
                result = true;
            }

            return result;
        }

        public static bool NotEmpty(string temp)
        {
            bool not_empty = false;

            if (temp.Length > 0)
            {
                not_empty = true;
            }

            return not_empty;
        }

        public static bool NotEmpty(int temp, int amount)
        {
            bool not_empty = false;

            if (temp >= amount)
            {
                not_empty = true;
            }

            return not_empty;
        }

        public static bool NotEmpty(string temp, int length_desired)
        {
            bool not_empty = false;

            if (temp.Length >= length_desired)
            {
                not_empty = true;
            }

            return not_empty;
        }

        public static bool NotEmpty(double temp, int amount)
        {
            bool not_empty = false;

            if (temp >= amount)
            {
                not_empty = true;
            }

            return not_empty;
        }


        public static bool IntCheck(string num)
        {
            int number_output;

            bool is_number = int.TryParse(num, out number_output);

            return is_number;
        }

        public static bool DoubleCheck(string num)
        {
            double double_output;

            bool is_number = double.TryParse(num, out double_output);

            return is_number;
        }

        public static bool ProfanityChecker(string temp)
        {
            bool is_bad = false;

            string[] profanities = { "SHIT", "FUCK", "ASSHOLE", "NAZI", "69", "HITLER", "HIMMLER", "COCK", "DICK", "POOP" };

            foreach (string word in profanities)
                if (temp.Contains(word))
                {
                    is_bad = true;
                }

            return is_bad;

        }



        public static bool EmailValidity(string email)
        {
            try
            {
                var email_address = new System.Net.Mail.MailAddress(email);
                return email_address.Address == email;
            }
            catch
            {
                return false;
            }
        }

        public static bool PhoneValidity(string temp)
        {
            var phone_reg = @"^[01]?[- .]?(\([2-9]\d{2}\)|[2-9]\d{2})[- .]?\d{3}[- .]?\d{4}$";
            var valid_phone = true;
            Regex reg = new Regex(phone_reg, RegexOptions.IgnoreCase | RegexOptions.Singleline);
            if (!reg.Match(temp).Success)
            {
                valid_phone = false;
            }
            return valid_phone;
        }

        public static bool isState(string temp)
        {
            bool is_state = false;
            temp = temp.ToUpper();
            string[] state_list = {"AL", "AK", "AZ", "AR", "CA", "CO", "CT", "DE", "FL",
                                  "GA", "HI", "ID", "IL", "IN", "IA", "KS", "KY", "LA",
                                  "ME", "MD", "MA", "MI", "MN", "MS", "MO", "MT", "NE",
                                  "NV", "NH", "NJ", "NM", "NY", "NC", "ND", "OH", "OK",
                                  "OR", "PA", "RI", "SC", "SD", "TN", "TX", "UT", "VT",
                                  "VA", "WA", "WV", "WI", "WY"};

            foreach (string state in state_list)
                if (temp.Contains(state))
                {
                    is_state = true;
                }
            return is_state;
        }



        public static bool isZip(string zipCode) //use regular expression for zip code to verify its a valid zip
        {
            var zip_reg = @"^\d{5}(?:[-\s]\d{4})?$";
            var valid_zip = true;
            Regex reg = new Regex(zip_reg, RegexOptions.IgnoreCase | RegexOptions.Singleline);
            if (!reg.Match(zipCode).Success)
            {
                valid_zip = false;
            }
            return valid_zip;
        }

        public static bool isFutureDate(DateTime date)
        {
            bool result;

            if (date <= DateTime.Now)
            {
                result = false;
            }
            else
            {
                result = true;
            }

            return result;
        }
    }
}