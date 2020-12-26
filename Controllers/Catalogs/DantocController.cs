using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using WebAPINetCore.Services;

namespace WebAPINetCore.Controllers.Catalogs
{
    [Route("api/dm/dan-toc")]
    [ApiController]
    public class DantocController : BaseController
    {
        private readonly IDantocService _dantocService;

        public DantocController(IDantocService dantocService)
        {
            this._dantocService = dantocService;
        }

        [HttpGet("")]
        public IActionResult GetAll()
        {
            var dantocs = _dantocService.SP_DM_DANTOC();

            if (dantocs == null)
            {
                return NotFound();
            }

            return Ok(dantocs);
        }

        [HttpGet("trang-thai/{trangthai:int}")]
        public IActionResult GetMulti(int trangthai)
        {
            var dantocs = _dantocService.SP_DM_DANTOC_TRANGTHAI(trangthai);

            if (dantocs == null)
            {
                return NotFound();
            }

            return Ok(dantocs);
        }

        [HttpPost("cap-nhat-trang-thai")]
        public IActionResult Toggle([FromBody] JsonElement content)
        {
            string ma = content.GetProperty("ma").GetString();
            int trangthai = content.GetProperty("trangthai").GetInt16();

            int results = _dantocService.SP_DM_DANTOC_CAPNHAT_TRANGTHAI(ma, trangthai);

            if (results == 0)
            {
                return NotFound();
            }

            return Ok(new { message = "Cập nhật thành công!" });
        }
    }
}
