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
    [Route("api/dm/hoc-van")]
    [ApiController]
    public class HocvanController : BaseController
    {
        private IHocvanService _hocvanService;
        public HocvanController(IHocvanService hocvanService)
        {
            _hocvanService = hocvanService;
        }

        [HttpGet("")]
        public IActionResult GetAll()
        {
            var HOCVANs = _hocvanService.SP_DM_HOCVAN();

            if (HOCVANs == null)
            {
                return NotFound();
            }

            return Ok(HOCVANs);
        }

        [HttpGet("ma/{ma:int}")]
        public IActionResult Get(int ma)
        {
            var HOCVAN = _hocvanService.SP_DM_HOCVAN_ID(ma);

            if (HOCVAN == null)
            {
                return NotFound();
            }

            return Ok(HOCVAN);
        }

        [HttpGet("trang-thai/{trangthai:int}")]
        public IActionResult GetMulti(int trangthai)
        {
            var HOCVANs = _hocvanService.SP_DM_HOCVAN_TRANGTHAI(trangthai);

            if (HOCVANs == null)
            {
                return NotFound();
            }

            return Ok(HOCVANs);
        }

        [HttpPost("cap-nhat-trang-thai")]
        public IActionResult Toggle([FromBody] JsonElement content)
        {
            int id = content.GetProperty("id").GetInt16();
            int trangthai = content.GetProperty("trangthai").GetInt16();

            int results = _hocvanService.SP_DM_HOCVAN_CAPNHAT_TRANGTHAI(id, trangthai);

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

            int results = _hocvanService.SP_DM_HOCVAN_INS(prmdata);

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

            int results = _hocvanService.SP_DM_HOCVAN_UPD(prmdata);

            if (results == 0)
            {
                return NotFound();
            }

            return Ok(new { message = "Thêm mới thành công!" });
        }

        [HttpPost("xoa/{ma:int}")]
        public IActionResult Delete(int ma)
        {
            int results = _hocvanService.SP_DM_HOCVAN_DEL(ma);

            if (results == 0)
            {
                return NotFound();
            }

            return Ok(new { message = "Xóa thành công!" });
        }
    }
}
