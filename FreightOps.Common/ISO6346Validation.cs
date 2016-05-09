using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FreightOps.Common
{
    public class ISO6346Validation
    {
        /// <summary>
        /// https://en.wikipedia.org/wiki/ISO_6346
        /// </summary>
        /// <param name="con"></param>
        /// <returns></returns>
        public bool Validate(string containerNumber)
        {
            string charCode = "0123456789A?BCDEFGHIJK?LMNOPQRSTU?VWXYZ";
            if (string.IsNullOrWhiteSpace(containerNumber))
            {
                return false;
            }

            containerNumber = containerNumber.Trim().ToUpper();
            if (containerNumber.Length != 11)
            {
                return false;
            }

            int num = 0;
            for (int i = 0; i < 10; i++)
            {
                char chr = containerNumber[i];//.Substring(i, 1);
                int idx = chr == '?' ? -1 : charCode.IndexOf(chr);
                if (idx < 0)
                {
                    return false;
                }
                idx = idx * (int)Math.Pow((double)2, (double)i);
                num += idx;
            }
            num = (num % 11) % 10;
            return int.Parse(containerNumber.Substring(10, 1)) == num;
        }
    }
}
