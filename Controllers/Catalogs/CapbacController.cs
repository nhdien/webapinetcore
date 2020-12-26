using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using WebAPINetCore.Services;

namespace WebAPINetCore.Controllers.Catalogs
{
    [Route("api/dm/cap-bac")]
    [ApiController]
    public class CapbacController : BaseController
    {
        private ICapbacService _capbacService;
        public CapbacController(ICapbacService capbacService)
        {
            _capbacService = capbacService;
        }

        [HttpGet("")]
        public IActionResult GetAll()
        {
            var CAPBACs = _capbacService.SP_DM_CAPBAC();

            if (CAPBACs == null)
            {
                return NotFound();
            }

            return Ok(CAPBACs);
        }

        [HttpGet("ma/{id:int}")]
        public IActionResult Get(int id)
        {
            var CAPBAC = _capbacService.SP_DM_CAPBAC_ID(id);

            if (CAPBAC == null)
            {
                return NotFound();
            }

            return Ok(CAPBAC);
        }

        [HttpGet("trang-thai/{trangthai:int}")]
        public IActionResult GetMulti(int trangthai)
        {
            var CAPBACs = _capbacService.SP_DM_CAPBAC_TRANGTHAI(trangthai);

            if (CAPBACs == null)
            {
                return NotFound();
            }

            return Ok(CAPBACs);
        }

        [HttpPost("cap-nhat-trang-thai")]
        public IActionResult Toggle([FromBody] JsonElement content)
        {
            int id = content.GetProperty("id").GetInt16();
            int trangthai = content.GetProperty("trangthai").GetInt16();

            int results = _capbacService.SP_DM_CAPBAC_CAPNHAT_TRANGTHAI(id, trangthai);

            if (results == 0)
            {
                return NotFound();
            }

            return Ok(new { message = "Cập nhật thành công!" });
        }

        [HttpPost("them-moi")]
        public IActionResult Insert([FromBody] JsonElement content)
        {
            string prmdata = content.GetProperty("prmdata").GetString();

            int results = _capbacService.SP_DM_CAPBAC_INS(prmdata);

            if (results == 0)
            {
                return NotFound();
            }

            return Ok(new { message = "Thêm mới thành công!" });
        }

        [HttpPost("cap-nhat")]
        public IActionResult Update([FromBody] JsonElement content)
        {
            string prmdata = content.GetProperty("prmdata").GetString();

            int results = _capbacService.SP_DM_CAPBAC_UPD(prmdata);

            if (results == 0)
            {
                return NotFound();
            }

            return Ok(new { message = "Thêm mới thành công!" });
        }

        [HttpPost("xoa/{id:int}")]
        public IActionResult Delete(int id)
        {
            int results = _capbacService.SP_DM_CAPBAC_DEL(id);

            if (results == 0)
            {
                return NotFound();
            }

            return Ok(new { message = "Xóa thành công!" });
        }
    }
}
