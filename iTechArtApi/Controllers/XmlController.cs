using iTechArtApi.IRepositories;
using iTechArtApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace iTechArtApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class XmlController : ControllerBase
    {
        public IXmlRepository _xmlRepository;
        public XmlController(IXmlRepository xmlRepository)
        {
            _xmlRepository = xmlRepository;
        }

        //Transfer data from database to the Xml
        [HttpGet]
        public void XmlCreate()
        {
            _xmlRepository.Createxml();
        }
    }
}
