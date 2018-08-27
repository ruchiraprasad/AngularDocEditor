using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DocumentEditor.API.Models
{
    public class Field
    {
        public int Id { get; set; }
        public string Category { get; set; }
        public string Name { get; set; }
        public string DisplayName { get; set; }
        public string Value { get; set; }
    }


    public class FieldDisplayCategory
    {
        public string Category { get; set; }
        public IEnumerable<Field> Fields { get; set; }
    }

}
