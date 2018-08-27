using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DocumentEditor.API.Models
{
    [Table("Template")]
    public class Template
    {
        public int Id { get; set; }
        public string TemplateName { get; set; }
        public string TemplateContent { get; set; }
    }
}
