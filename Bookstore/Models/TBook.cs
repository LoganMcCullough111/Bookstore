using System;
using System.Collections.Generic;

#nullable disable

namespace Bookstore.Models
{
    public partial class TBook
    {
        public TBook()
        {
            TOrderLines = new HashSet<TOrderLine>();
        }

        public string FIsbn { get; set; }
        public long FAuthorId { get; set; }
        public string FTitle { get; set; }
        public long FPubId { get; set; }
        public long FPubYear { get; set; }
        public string FBinding { get; set; }
        public long FSourceId { get; set; }
        public byte[] FRetailPrice { get; set; }
        //Convert the field fRetailPrice to a string denoting the actual number.
        public string RPrice
        {
            get
            {
                //Loop through the bytes in the byte array FRetailPrice, convert
                // Each to a character, and append the characters to the output string
                string strOutput = "";
                foreach (byte byOneChar in FRetailPrice)
                {
                    strOutput += Convert.ToChar(byOneChar);
                }
                return strOutput;
            }
        }
        public long FNumInStock { get; set; }

        public virtual TAuthor FAuthor { get; set; }
        public virtual TPublisher FPub { get; set; }
        public virtual TSource FSource { get; set; }
        public virtual ICollection<TOrderLine> TOrderLines { get; set; }
    }
}