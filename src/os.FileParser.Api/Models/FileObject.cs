using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace os.FileParser.Api.Models
{
    public class FileObject
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Data { get; set; }
    }
}