using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace DocumentEditor.API.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        // GET api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }


        [HttpGet("GetTemplateList")]
        public IActionResult GetTemplateList()
        {
            return Ok(new List<TemplateListItem>()
            {
                new TemplateListItem(){ Name = "Template1", ContainerId = "Template 1", DisplayName = "Template 1 Name", Content= "Template 1 content display" },
                new TemplateListItem(){ Name = "Template2", ContainerId = "Template 2", DisplayName = "Template 2 Name", Content= "Template 2 content display" },
                new TemplateListItem(){ Name = "Template3", ContainerId = "Template 3", DisplayName = "Template 3 Name", Content= "Template 3 content display" },
                new TemplateListItem(){ Name = "Template4", ContainerId = "Template 4", DisplayName = "Template 4 Name", Content= "Template 4 content display" },
                new TemplateListItem(){ Name = "Template5", ContainerId = "Template 5", DisplayName = "Template 5 Name", Content= "Template 5 content display" },
            });
        }


        [HttpGet("GetTemplate/{name}")]
        public IActionResult GetTemplateList(string name)
        {
            var txt = System.IO.File.ReadAllText(@"template.txt");
            txt = txt.Replace("{@@name}", name);
            return  Ok(txt);
        }
    }


    public class TemplateListItem
    {
        public string Name { get; set; }
        public string ContainerId { get; set; }
        public string DisplayName { get; set; }
        public string Content { get; set; }

    }
}
