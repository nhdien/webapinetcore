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
    [Route("api/dm/quan-he-than-nhan")]
    [ApiController]
    public class QuanheController : BaseController
    {
        private IQuanheService _quanheService;
        public QuanheController(IQuanheService quanheService)
        {
            _quanheService = quanheService;
        }
        [HttpGet("")]
        public IActionResult GetAll()
        {
            var QUANHEs = _quanheService.SP_DM_QUANHE();

            if (QUANHEs == null)
            {
                return NotFound();
            }

            return Ok(QUANHEs);
        }

        [HttpGet("ma/{ma:int}")]
        public IActionResult Get(int ma)
        {
            var QUANHE = _quanheService.SP_DM_QUANHE_ID(ma);

            if (QUANHE == null)
            {
                return NotFound();
            }

            return Ok(QUANHE);
        }

        [HttpGet("trang-thai/{trangthai:int}")]
        public IActionResult GetMulti(int trangthai)
        {
            var QUANHEs = _quanheService.SP_DM_QUANHE_TRANGTHAI(trangthai);

            if (QUANHEs == null)
            {
                return NotFound();
            }

            return Ok(QUANHEs);
        }

        [HttpPost("cap-nhat-trang-thai")]
        public IActionResult Toggle([FromBody] JsonElement content)
        {
            int id = content.GetProperty("id").GetInt16();
            int trangthai = content.GetProperty("trangthai").GetInt16();

            int results = _quanheService.SP_DM_QUANHE_CAPNHAT_TRANGTHAI(id, trangthai);

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

            int results = _quanheService.SP_DM_QUANHE_INS(prmdata);

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

            int results = _quanheService.SP_DM_QUANHE_UPD(prmdata);

            if (results == 0)
            {
                return NotFound();
            }

            return Ok(new { message = "Cập nhật thành công!" });
        }

        [HttpPost("xoa/{ma:int}")]
        public IActionResult Delete(int ma)
        {
            int results = _quanheService.SP_DM_QUANHE_DEL(ma);

            if (results == 0)
            {
                return NotFound();
            }

            return Ok(new { message = "Xóa thành công!" });
        }
    }
}
