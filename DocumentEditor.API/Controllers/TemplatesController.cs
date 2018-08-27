using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DocumentEditor.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace DocumentEditor.API.Controllers
{
    [Route("api/[controller]")]
    public class TemplatesController : Controller
    {
        [HttpGet]
        public IEnumerable<Template> Get()
        {
            using (var db = new TestDocDbContext())
            {
                var templates = db.Templates.ToList();
                return templates;
            }
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            using (var db = new TestDocDbContext())
            {
                var template = db.Templates.FirstOrDefault(x => x.Id == id);

                var txt = System.IO.File.ReadAllText(@"template.txt");
                txt = txt.Replace("{@@name}", "Template 1");
                template.TemplateContent = txt;

                return Ok(template.TemplateContent);
            }
        }

        //[HttpGet, Route("templates/{templateId}")]
        //public IActionResult GetTemplate(string templateId)
        //{
        //    using (var db = new TestDocDbContext())
        //    {
        //        var template = db.Templates.FirstOrDefault(x => x.Id == int.Parse(templateId));
        //        return Ok(template);
        //    }
        //}
    }
}