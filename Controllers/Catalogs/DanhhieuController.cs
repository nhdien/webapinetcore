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
    [Route("api/dm/danh-hieu")]
    [ApiController]
    public class DanhhieuController : BaseController
    {
        private IDanhhieuService _danhhieuService;
        public DanhhieuController(IDanhhieuService danhhieuService)
        {
            _danhhieuService = danhhieuService;
        }

        [HttpGet("")]
        public IActionResult GetAll()
        {
            var DANHHIEUs = _danhhieuService.SP_DM_DANHHIEU();

            if (DANHHIEUs == null)
            {
                return NotFound();
            }

            return Ok(DANHHIEUs);
        }

        [HttpGet("ma/{id:int}")]
        public IActionResult Get(int id)
        {
            var DANHHIEU = _danhhieuService.SP_DM_DANHHIEU_ID(id);

            if (DANHHIEU == null)
            {
                return NotFound();
            }

            return Ok(DANHHIEU);
        }

        [HttpGet("trang-thai/{trangthai:int}")]
        public IActionResult GetMulti(int trangthai)
        {
            var DANHHIEUs = _danhhieuService.SP_DM_DANHHIEU_TRANGTHAI(trangthai);

            if (DANHHIEUs == null)
            {
                return NotFound();
            }

            return Ok(DANHHIEUs);
        }

        [HttpPost("cap-nhat-trang-thai")]
        public IActionResult Toggle([FromBody] JsonElement content)
        {
            int id = content.GetProperty("id").GetInt16();
            int trangthai = content.GetProperty("trangthai").GetInt16();

            int results = _danhhieuService.SP_DM_DANHHIEU_CAPNHAT_TRANGTHAI(id, trangthai);

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

            int results = _danhhieuService.SP_DM_DANHHIEU_INS(prmdata);

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

            int results = _danhhieuService.SP_DM_DANHHIEU_UPD(prmdata);

            if (results == 0)
            {
                return NotFound();
            }

            return Ok(new { message = "Thêm mới thành công!" });
        }

        [HttpPost("xoa/{id:int}")]
        public IActionResult Delete(int id)
        {
            int results = _danhhieuService.SP_DM_DANHHIEU_DEL(id);

            if (results == 0)
            {
                return NotFound();
            }

            return Ok(new { message = "Xóa thành công!" });
        }
    }
}
