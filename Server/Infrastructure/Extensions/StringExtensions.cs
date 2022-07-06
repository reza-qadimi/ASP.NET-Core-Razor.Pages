namespace Infrastructure.Extensions
{
    public static class StringExtensions
    {
        /// <summary>
        /// تبدیل اعداد انگلیسی به فارسی
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string En2Fa(this string str)
        {
            if (string.IsNullOrWhiteSpace(str))
                return string.Empty;

            return string.Create(str.Length, str, (chars, context) =>
            {
                for (var i = 0; i < str.Length; i++)
                {
                    switch (context[i])
                    {
                        case '0':
                            chars[i] = '۰';
                            break;
                        case '1':
                            chars[i] = '۱';
                            break;
                        case '2':
                            chars[i] = '۲';
                            break;
                        case '3':
                            chars[i] = '۳';
                            break;
                        case '4':
                            chars[i] = '۴';
                            break;
                        case '5':
                            chars[i] = '۵';
                            break;
                        case '6':
                            chars[i] = '۶';
                            break;
                        case '7':
                            chars[i] = '۷';
                            break;
                        case '8':
                            chars[i] = '۸';
                            break;
                        case '9':
                            chars[i] = '۹';
                            break;
                        default:
                            chars[i] = context[i];
                            break;
                    }
                }
            });
        }

        /// <summary>
        /// تبدیل اعداد فارسی به انگلیسی
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string Fa2En(this string str)
        {
            if (string.IsNullOrWhiteSpace(str))
                return string.Empty;
            return string.Create(str.Length, str, (chars, context) =>
            {
                for (var i = 0; i < str.Length; i++)
                {
                    switch (context[i])
                    {
                        case '۰':
                            chars[i] = '0';
                            break;
                        case '۱':
                            chars[i] = '1';
                            break;
                        case '۲':
                            chars[i] = '2';
                            break;
                        case '۳':
                            chars[i] = '3';
                            break;
                        case '۴':
                            chars[i] = '4';
                            break;
                        case '۵':
                            chars[i] = '5';
                            break;
                        case '۶':
                            chars[i] = '6';
                            break;
                        case '۷':
                            chars[i] = '7';
                            break;
                        case '۸':
                            chars[i] = '8';
                            break;
                        case '۹':
                            chars[i] = '9';
                            break;
                        //=========
                        case '٠':
                            chars[i] = '0';
                            break;
                        case '١':
                            chars[i] = '1';
                            break;
                        case '٢':
                            chars[i] = '2';
                            break;
                        case '٣':
                            chars[i] = '3';
                            break;
                        case '٤':
                            chars[i] = '4';
                            break;
                        case '٥':
                            chars[i] = '5';
                            break;
                        case '٦':
                            chars[i] = '6';
                            break;
                        case '٧':
                            chars[i] = '7';
                            break;
                        case '٨':
                            chars[i] = '8';
                            break;
                        case '٩':
                            chars[i] = '9';
                            break;
                        default:
                            chars[i] = context[i];
                            break;
                    }
                }
            });

        }
    }
}
