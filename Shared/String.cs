using System.Text;
using System.Reflection;
using System.Security.Cryptography;
using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace Shared
{
	public static class String
    {
        static String()
        {
        }

        public static string Fix(this string? text)
        {
            if (text == null)
                return string.Empty;

            text = text.Trim().ToLower();

            if (text == string.Empty)
                return string.Empty;

            while (text.Contains("  "))
            {
                text =
                    text.Replace("  ", " ");
            }

            return text;
        }

        public static string? Encode(this string value)
        {
            if (string.IsNullOrEmpty(value: value))
                return null;

            // Create a SHA256   
            using var sha256Hash = SHA256.Create();

            // ComputeHash - returns byte array  
            byte[] bytes =
                sha256Hash.ComputeHash(buffer: Encoding.UTF8.GetBytes(s: value));

            // Convert byte array to a string   
            var builder = new StringBuilder();

            for (int i = 0; i < bytes.Length; i++)
            {
                builder.Append(bytes[i].ToString("x2"));
            }

            return builder.ToString();
        }

        public static string? GetEnumName(this System.Enum myEnum)
		{
            var enumDisplayName = 
                myEnum.GetType().GetMember(name: myEnum.ToString()).FirstOrDefault();

            if(enumDisplayName != null)
			{
                var result = 
                    enumDisplayName.GetCustomAttribute<DisplayAttribute>()?.GetName();

                return result;
			}

            return string.Empty;
        }

        public static DateTime ConvertPersianDate(this string value)
        {
            var p = new PersianCalendar();
            string PersianDate1 = value;
            string[] parts = PersianDate1.Split('/', '-');
            DateTime dta1 = p.ToDateTime(Convert.ToInt32(parts[0]), Convert.ToInt32(parts[1]), Convert.ToInt32(parts[2]), 0, 0, 0, 0);

            return dta1;
        }
    }
}

