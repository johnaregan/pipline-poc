using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Bordereau.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BaseController : ControllerBase
    {
        public IMediator Mediator;

        public static T GetObject<T>(string fileName)
        {
            var reader = new XmlSerializer(typeof(T));
            var currentDirectory = Directory.GetCurrentDirectory();
            T item = default;
            using (var file = new StreamReader($@"{currentDirectory}\{fileName}"))
            {
                item = (T)reader.Deserialize(file);
            }
            return item;
        }

    }
}