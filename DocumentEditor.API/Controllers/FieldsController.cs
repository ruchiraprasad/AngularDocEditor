using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DocumentEditor.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace DocumentEditor.API.Controllers
{
    [Route("api/[controller]")]
    public class FieldsController : Controller
    {
        [HttpGet]
        public IEnumerable<FieldDisplayCategory> Get()
        {
            using (var db = new TestDocDbContext())
            {
                var templates = db.Fields.GroupBy(e => e.Category).Select(e => new FieldDisplayCategory() { Category = e.Key, Fields = e.ToList() }).ToList();
                return templates;
            }
        }
    }
}