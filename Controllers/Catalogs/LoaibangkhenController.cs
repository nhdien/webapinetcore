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
    [Route("api/dm/loai-bang-khen")]
    [ApiController]
    public class LoaibangkhenController : BaseController
    {
        private ILoaibangkhenService _loaibangkhenService;
        public LoaibangkhenController(ILoaibangkhenService loaibangkhenService)
        {
            _loaibangkhenService = loaibangkhenService;
        }

        [HttpGet("")]
        public IActionResult GetAll()
        {
            var LOAIBANGKHENs = _loaibangkhenService.SP_DM_LOAIBANGKHEN();

            if (LOAIBANGKHENs == null)
            {
                return NotFound();
            }

            return Ok(LOAIBANGKHENs);
        }

        [HttpGet("ma/{id:int}")]
        public IActionResult Get(int id)
        {
            var LOAIBANGKHEN = _loaibangkhenService.SP_DM_LOAIBANGKHEN_ID(id);

            if (LOAIBANGKHEN == null)
            {
                return NotFound();
            }

            return Ok(LOAIBANGKHEN);
        }

        [HttpGet("trang-thai/{trangthai:int}")]
        public IActionResult GetMulti(int trangthai)
        {
            var LOAIBANGKHENs = _loaibangkhenService.SP_DM_LOAIBANGKHEN_TRANGTHAI(trangthai);

            if (LOAIBANGKHENs == null)
            {
                return NotFound();
            }

            return Ok(LOAIBANGKHENs);
        }

        [HttpPost("cap-nhat-trang-thai")]
        public IActionResult Toggle([FromBody] JsonElement content)
        {
            int id = content.GetProperty("id").GetInt16();
            int trangthai = content.GetProperty("trangthai").GetInt16();

            int results = _loaibangkhenService.SP_DM_LOAIBANGKHEN_CAPNHAT_TRANGTHAI(id, trangthai);

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

            int results = _loaibangkhenService.SP_DM_LOAIBANGKHEN_INS(prmdata);

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

            int results = _loaibangkhenService.SP_DM_LOAIBANGKHEN_UPD(prmdata);

            if (results == 0)
            {
                return NotFound();
            }

            return Ok(new { message = "Thêm mới thành công!" });
        }

        [HttpPost("xoa/{id:int}")]
        public IActionResult Delete(int id)
        {
            int results = _loaibangkhenService.SP_DM_LOAIBANGKHEN_DEL(id);

            if (results == 0)
            {
                return NotFound();
            }

            return Ok(new { message = "Xóa thành công!" });
        }
    }
}
