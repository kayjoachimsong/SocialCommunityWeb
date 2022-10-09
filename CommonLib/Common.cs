using log4net;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Web;

namespace CommonLib
{
    public static class Common
    {
        /// <summary>
        /// Constructor
        /// </summary>
        static Common()
        {
        }

        public static bool IsNumber( string strNumber )
        {
            Regex regNotNumberPattern = new Regex("[^0-9.-]");
            Regex regTwoDotPattern = new Regex("[0-9]*[.][0-9]*[.][0-9]*");
            Regex regTwoMinusPattern = new Regex("[0-9]*[-][0-9]*[-][0-9]*");
            String strValidRealPattern = "^([-]|[.]|[-.]|[0-9])[0-9]*[.]*[0-9]+$";
            String strValidIntegerPattern = "^([-]|[0-9])[0-9]*$";
            Regex regNumberPattern = new Regex("(" + strValidRealPattern + ")|(" + strValidIntegerPattern + ")");

            if ( regNotNumberPattern.IsMatch(strNumber) &&
                !regTwoDotPattern.IsMatch(strNumber) &&
                !regTwoMinusPattern.IsMatch(strNumber) &&
                regNumberPattern.IsMatch(strNumber) )
            {
                return false;
            }
            return true;
        }


        public static bool IsAlpha( string strToCheck )
        {
            Regex regAlphaPattern = new Regex("[^a-zA-Z]");

            if ( regAlphaPattern.IsMatch(strToCheck) )
            {
                return false;
            }
            return true;
        }

        public static bool IsValidEmail( string email )
        {
            string emailPattern = @"^[a-zA-Z][\w\.-]*[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$";
            Regex regEmailPattern = new Regex(emailPattern);
            if ( regEmailPattern.IsMatch(email) )
            {
                return false;
            }
            return true;

        }

        public static bool IsAlphaNumeric( string strToCheck )
        {
            Regex regAlphaNumericPattern = new Regex("[^a-zA-Z0-9]");

            if ( regAlphaNumericPattern.IsMatch(strToCheck) )
            {
                return false;
            }
            return true;
        }

        public static string RemoveHtmlTag( string html )
        {
            return Regex.Replace(html, @"<(.|\n)*?>", string.Empty);
        }
    }

    public static class Logger
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(Logger));

        /// <summary>
        /// Print a message.
        /// </summary>
        /// <param name="msg"></param>
        public static void Info( string msg )
        {
            log.Info(msg);
        }

        /// <summary>
        /// Print a function name.
        /// </summary>
        public static void Info( object obj )
        {
            log.Info($"[{obj.GetType().Name}]");
        }

        /// <summary>
        /// Print an object with a function name.
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="val"></param>
        public static void Info( object obj, object val )
        {
            log.Info($"[{obj.GetType().Name}] {val}");
        }

        /// <summary>
        /// Print a message with a function name.
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="msg"></param>
        public static void Info( object obj, string msg )
        {
            log.Info($"[{obj.GetType().Name}] {msg}");
        }

        /// <summary>
        /// Print an error object.
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="e"></param>
        public static void Error( object obj, object e )
        {
            log.Info($"[{obj.GetType().Name}.{( (Exception)e ).TargetSite.Name}] {( (Exception)e ).Message}");
        }
    }

    public static class RequestExtensions
    {
        //regex from http://detectmobilebrowsers.com/
        private static readonly Regex b = new Regex(@"(android|bb\d+|meego).+mobile|avantgo|bada\/|blackberry|blazer|compal|elaine|fennec|hiptop|iemobile|ip(hone|od)|iris|kindle|lge |maemo|midp|mmp|mobile.+firefox|netfront|opera m(ob|in)i|palm( os)?|phone|p(ixi|re)\/|plucker|pocket|psp|series(4|6)0|symbian|treo|up\.(browser|link)|vodafone|wap|windows ce|xda|xiino", RegexOptions.IgnoreCase | RegexOptions.Multiline);
        private static readonly Regex v = new Regex(@"1207|6310|6590|3gso|4thp|50[1-6]i|770s|802s|a wa|abac|ac(er|oo|s\-)|ai(ko|rn)|al(av|ca|co)|amoi|an(ex|ny|yw)|aptu|ar(ch|go)|as(te|us)|attw|au(di|\-m|r |s )|avan|be(ck|ll|nq)|bi(lb|rd)|bl(ac|az)|br(e|v)w|bumb|bw\-(n|u)|c55\/|capi|ccwa|cdm\-|cell|chtm|cldc|cmd\-|co(mp|nd)|craw|da(it|ll|ng)|dbte|dc\-s|devi|dica|dmob|do(c|p)o|ds(12|\-d)|el(49|ai)|em(l2|ul)|er(ic|k0)|esl8|ez([4-7]0|os|wa|ze)|fetc|fly(\-|_)|g1 u|g560|gene|gf\-5|g\-mo|go(\.w|od)|gr(ad|un)|haie|hcit|hd\-(m|p|t)|hei\-|hi(pt|ta)|hp( i|ip)|hs\-c|ht(c(\-| |_|a|g|p|s|t)|tp)|hu(aw|tc)|i\-(20|go|ma)|i230|iac( |\-|\/)|ibro|idea|ig01|ikom|im1k|inno|ipaq|iris|ja(t|v)a|jbro|jemu|jigs|kddi|keji|kgt( |\/)|klon|kpt |kwc\-|kyo(c|k)|le(no|xi)|lg( g|\/(k|l|u)|50|54|\-[a-w])|libw|lynx|m1\-w|m3ga|m50\/|ma(te|ui|xo)|mc(01|21|ca)|m\-cr|me(rc|ri)|mi(o8|oa|ts)|mmef|mo(01|02|bi|de|do|t(\-| |o|v)|zz)|mt(50|p1|v )|mwbp|mywa|n10[0-2]|n20[2-3]|n30(0|2)|n50(0|2|5)|n7(0(0|1)|10)|ne((c|m)\-|on|tf|wf|wg|wt)|nok(6|i)|nzph|o2im|op(ti|wv)|oran|owg1|p800|pan(a|d|t)|pdxg|pg(13|\-([1-8]|c))|phil|pire|pl(ay|uc)|pn\-2|po(ck|rt|se)|prox|psio|pt\-g|qa\-a|qc(07|12|21|32|60|\-[2-7]|i\-)|qtek|r380|r600|raks|rim9|ro(ve|zo)|s55\/|sa(ge|ma|mm|ms|ny|va)|sc(01|h\-|oo|p\-)|sdk\/|se(c(\-|0|1)|47|mc|nd|ri)|sgh\-|shar|sie(\-|m)|sk\-0|sl(45|id)|sm(al|ar|b3|it|t5)|so(ft|ny)|sp(01|h\-|v\-|v )|sy(01|mb)|t2(18|50)|t6(00|10|18)|ta(gt|lk)|tcl\-|tdg\-|tel(i|m)|tim\-|t\-mo|to(pl|sh)|ts(70|m\-|m3|m5)|tx\-9|up(\.b|g1|si)|utst|v400|v750|veri|vi(rg|te)|vk(40|5[0-3]|\-v)|vm40|voda|vulc|vx(52|53|60|61|70|80|81|83|85|98)|w3c(\-| )|webc|whit|wi(g |nc|nw)|wmlb|wonu|x700|yas\-|your|zeto|zte\-", RegexOptions.IgnoreCase | RegexOptions.Multiline);

        public static bool IsMobileBrowser( this HttpRequest request )
        {
            var userAgent = request.UserAgent();
            if ( ( b.IsMatch(userAgent) || v.IsMatch(userAgent.Substring(0, 4)) ) )
            {
                return true;
            }
            return false;
        }

        public static string UserAgent( this HttpRequest request )
        {
            if ( ( request.Headers["User-Agent"] ?? "" ).Trim().Length > 0 )
            {
                return request.Headers["User-Agent"];
            }
            else
            {
                return string.Empty;
            }
        }
    }

    public class Paginate
    {
        public int numCurrentPage = 1;

        public int iMaxPageLength;

        public List<string[]> numPageArray = new List<string[]>();

        public List<string[]> numPageLeap = new List<string[]>();

        public Paginate SetPaginate( int p_numCurrentPage, int p_numPageLength, int p_iTotalCnt )
        {
            Paginate paginate = new Paginate();
            int num = paginate.iMaxPageLength = (int)Math.Ceiling((double)p_iTotalCnt / (double)p_numPageLength);
            string empty = string.Empty;
            string empty2 = string.Empty;
            paginate.numCurrentPage = p_numCurrentPage;
            int num2 = 0;
            int num3 = 0;
            for ( int i = 0; i < paginate.iMaxPageLength; i++ )
            {
                int num4 = i + 1;
                empty = ( ( num4 == paginate.numCurrentPage ) ? "active" : string.Empty );
                empty2 = ( ( num4 == paginate.numCurrentPage ) ? "#" : string.Empty );
                if ( num4 == paginate.numCurrentPage )
                {
                    paginate.numPageLeap.Add(new string[4]
                    {
                        num4.ToString(),
                        num4.ToString(),
                        " selected",
                        string.Empty
                    });
                }
                else
                {
                    paginate.numPageLeap.Add(new string[4]
                    {
                        num4.ToString(),
                        num4.ToString(),
                        string.Empty,
                        string.Empty
                    });
                }

                if ( num4 == 1 )
                {
                    paginate.numPageArray.Add(new string[4]
                    {
                        num4.ToString(),
                        "1",
                        empty,
                        empty2
                    });
                }

                if ( num4 > 1 && num4 < paginate.iMaxPageLength )
                {
                    if ( paginate.numCurrentPage - 4 >= num4 )
                    {
                        num2++;
                        if ( paginate.numCurrentPage - 4 == num4 )
                        {
                            paginate.numPageArray.Add(new string[4]
                            {
                                num4.ToString(),
                                "...",
                                string.Empty,
                                string.Empty
                            });
                        }

                        continue;
                    }

                    if ( paginate.numCurrentPage + 4 <= num4 )
                    {
                        num3++;
                        if ( paginate.numCurrentPage + 4 == num4 )
                        {
                            paginate.numPageArray.Add(new string[4]
                            {
                                num4.ToString(),
                                "...",
                                string.Empty,
                                string.Empty
                            });
                        }

                        continue;
                    }

                    paginate.numPageArray.Add(new string[4]
                    {
                        num4.ToString(),
                        num4.ToString(),
                        empty,
                        empty2
                    });
                }

                if ( paginate.iMaxPageLength > 1 && num4 == paginate.iMaxPageLength )
                {
                    paginate.numPageArray.Add(new string[4]
                    {
                        num4.ToString(),
                        paginate.iMaxPageLength.ToString(),
                        empty,
                        empty2
                    });
                }
            }

            return paginate;
        }

        public void GetPaginate( int p_numCurrentPage, int p_numPageLength, int p_iTotalCnt, ref Paginate p_objPaginate )
        {
            p_objPaginate = SetPaginate(p_numCurrentPage, p_numPageLength, p_iTotalCnt);
        }
    }
}
