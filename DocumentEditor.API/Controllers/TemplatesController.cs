using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
                return Ok(template.TemplateContent);
            }
        }

        [HttpGet("{id}/document")]
        public IActionResult GetDocument(int id)
        {
            using (var db = new TestDocDbContext())
            {
                var template = db.Templates.FirstOrDefault(x => x.Id == id);
                return Ok(GenerateDocumentfromTemplate(template.TemplateContent));
            }
        }

        private string GenerateDocumentfromTemplate(string templateText)
        {
            var db = new TestDocDbContext();

            MatchCollection matches = Regex.Matches(templateText, "\\{@(.*?)\\}");

            StringBuilder result = new StringBuilder(templateText);

            foreach (Match match in matches)
            {
                switch (match.Value)
                {
                    case "{@name}":
                        result = result.Replace(match.Value, db.Fields.Where(e => e.Name == "Name").FirstOrDefault().Value);
                        break;
                    case "{@last-appointment-date}":
                        result = result.Replace(match.Value, DateTime.Now.Date.AddDays(-7).ToString("dd-MMM-yyyy"));
                        break;
                    case "{@date}":
                        result = result.Replace(match.Value, DateTime.Now.Date.ToString("dd-MMM-yyyy"));
                        break;
                    case "{@test}":
                        result = result.Replace(match.Value, db.Fields.Where(e => e.Name == "Test").FirstOrDefault().Value);
                        break;
                    default:
                        break;
                }

            }
            return result.ToString();
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