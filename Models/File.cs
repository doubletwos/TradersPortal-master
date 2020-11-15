using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TradersPortal.Models
{
    public class File
    {
        public int FileId { get; set; }
        [StringLength(255)]
        public string FileName { get; set; }
       
        [StringLength(100)]
        public string ContentType { get; set; }
        public byte[] Content { get; set; }
        public FileType FileType { get; set; }

        
        [ForeignKey("Trader")]
        public int TraderId { get; set; }
        public virtual Trader Trader { get; set; }
    }
}