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
                var newTemplates = templates.Select(s => new Template()
                {
                    Id = s.Id,
                    TemplateName = s.TemplateName
                });
                return newTemplates;
            }
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            using (var db = new TestDocDbContext())
            {
                var template = db.Templates.FirstOrDefault(x => x.Id == id);
                return Ok(template);
            }
        }

        [HttpGet("document/{id}")]
        public IActionResult GetDocument(int id)
        {
            using (var db = new TestDocDbContext())
            {
                var template = db.Templates.FirstOrDefault(x => x.Id == id);
                template.TemplateContent = GenerateDocumentfromTemplate(template.TemplateContent);
                return Ok(template);
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

        [HttpPost]
        public IActionResult Post([FromBody]Template model)
        {
            if (ModelState.IsValid)
            {
                var template = new Template();
                template.TemplateName = model.TemplateName;
                template.TemplateContent = model.TemplateContent;

                using (var db = new TestDocDbContext())
                {
                    if(model.Id == 0)
                    {
                        db.Templates.Add(template);
                    }
                    else
                    {
                        var templateUpdate = db.Templates.FirstOrDefault(x => x.Id == model.Id);
                        templateUpdate.TemplateName = model.TemplateName;
                        templateUpdate.TemplateContent = model.TemplateContent;
                    }

                    db.SaveChanges();
                }

                return Ok(template.Id);
            }

            return Ok();
        }

        //[HttpPost]
        //public IActionResult Post([FromBody] Template model)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        var template = new Template();
        //        template.TemplateName = model.TemplateName;
        //        template.TemplateContent = model.TemplateContent;

        //        using (var db = new TestDocDbContext())
        //        {
        //            db.Templates.Add(template);
        //            db.SaveChanges();
        //        }
        //    }


        //    return Ok();
        //}
    }
}