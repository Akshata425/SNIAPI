using System;
using System.Globalization;

namespace SNIAPI.Helpers
{
    public class Utility
    {
        public static DateTime? ConvertDateTime(DateTime? inputDate)
        {
            try
            {
                if (inputDate.HasValue)
                {
                    //return DateTime.ParseExact(inputDate.Value.ToString(), "yyyy/MM/dd", CultureInfo.InvariantCulture).ToString("dd/MM/yyyy");

                    DateTime ret = DateTime.Now;
                    if (DateTime.TryParseExact(inputDate.ToString(), "yyyy/MM/dd", CultureInfo.InvariantCulture, DateTimeStyles.AssumeLocal, out ret))
                    {
                        return ret;
                    }
                }
            }
            catch (Exception ex)
            {
               
            }
            return null;
        }
    }
}