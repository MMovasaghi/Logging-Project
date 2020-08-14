using System;
using System.ComponentModel.DataAnnotations;

namespace logMiddlewareProject.Models
{
    public class log
    {
        [Key]
        public int id { get; set; }
        public string Method { get; set; }
        public string Url { get; set; }
        public string username { get; set; }
        public int? StatusCode { get; set; }
        public DateTime created_at { get; set; }
    }
}