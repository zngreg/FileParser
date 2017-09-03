using System;
using os.FileParser.Api.Models;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;
using os.FileParser.Common.Utilities;

namespace os.FileParser.Api.Controllers
{
    [RoutePrefix("api/Files"), EnableCors(origins: "*", headers: "*", methods: "*")]
    public class FilesController : ApiController
    {
        [HttpPost, Route("names")]
        public IHttpActionResult LoadNamesFile(FileObject model)
        {
            if (!ModelState.IsValid)
                return BadRequest("File cannot be empty.");

            var items = ReadCsvFile(GetUploadedFile(model));

            var sorted = items
                .GroupBy(i => i)
                .OrderByDescending(i => i.Count())
                .ThenBy(i => i.Key)
                .Select(g => new { Name = g.Key, Frequency = g.Count() })
                .ToList();

            return Ok(sorted);
        }

        [HttpPost, Route("address")]
        public IHttpActionResult LoadAddressFile(FileObject model)
        {
            if (!ModelState.IsValid)
                return BadRequest("File cannot be empty.");

            var items = new List<Address>();

            ReadCsvFile(GetUploadedFile(model)).ForEach(i =>
            {
                var str = i.Split(',');

                if(str.Length < 3)
                    return;

                items.Add(new Address
                {
                    StreetNumber = str[0],
                    StreetName = str[1],
                    ZipCode = str[2]
                });
            });

            var sorted = items
                .OrderBy(i => i.StreetName)
                .ToList();

            return Ok(sorted);
        }
        
        private string GetUploadedFile(FileObject model)
        {
            if (model?.Data != null)
            {
                var root = HttpContext.Current.Server.MapPath("~/App_Data/uploads");

                if (!Directory.Exists(root))
                    Directory.CreateDirectory(root);

                model.Data = model.Data.Substring(model.Data.IndexOf(",", StringComparison.Ordinal) + 1);

                var filebytes = Convert.FromBase64String(model.Data);

                var fileName = Path.Combine(root, model.Name);

                if (FileManipulator.SaveByteArrayFile(filebytes, fileName))
                    return fileName;
            }

            return null;
        }

        private List<string> ReadCsvFile(string fileName)
        {
            var items = new List<string>();

            using (var reader = new StreamReader(fileName))
            {
                while (!reader.EndOfStream)
                {
                    items.Add(reader.ReadLine());
                }
            }

            return items;
        }
    }
}
