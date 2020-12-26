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
    [Route("api/dm/ton-giao")]
    [ApiController]
    public class TongiaoController : BaseController
    {
        private ITongiaoService _tongiaoService;
        public TongiaoController(ITongiaoService tongiaoService)
        {
            _tongiaoService = tongiaoService;
        }

        [HttpGet("")]
        public IActionResult GetAll()
        {
            var tongiaos = _tongiaoService.SP_DM_TONGIAO();

            if (tongiaos == null)
            {
                return NotFound();
            }

            return Ok(tongiaos);
        }

        [HttpGet("ma/{ma}")]
        public IActionResult Get(string ma)
        {
            var tongiao = _tongiaoService.SP_DM_TONGIAO_MA(ma);

            if (tongiao == null)
            {
                return NotFound();
            }

            return Ok(tongiao);
        }

        [HttpGet("trang-thai/{trangthai:int}")]
        public IActionResult GetMulti(int trangthai)
        {
            var tongiaos = _tongiaoService.SP_DM_TONGIAO_TRANGTHAI(trangthai);

            if (tongiaos == null)
            {
                return NotFound();
            }

            return Ok(tongiaos);
        }

        [HttpPost("cap-nhat-trang-thai")]
        public IActionResult Toggle([FromBody] JsonElement content)
        {
            string ma = content.GetProperty("ma").GetString();
            int trangthai = content.GetProperty("trangthai").GetInt16();

            int results = _tongiaoService.SP_DM_TONGIAO_CAPNHAT_TRANGTHAI(ma, trangthai);

            if (results == 0)
            {
                return NotFound();
            }

            return Ok(new { message = "Cập nhật thành công!" });
        }

        [HttpPost("them-moi")]
        public IActionResult Insert([FromBody]JsonElement content)
        {
            string prmdata = content.GetProperty("prmdata").GetString();

            int results = _tongiaoService.SP_DM_TONGIAO_INS(prmdata);

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

            int results = _tongiaoService.SP_DM_TONGIAO_UPD(prmdata);

            if (results == 0)
            {
                return NotFound();
            }

            return Ok(new { message = "Thêm mới thành công!" });
        }

        [HttpPost("xoa/{ma}")]
        public IActionResult Delete(string ma)
        {
            int results = _tongiaoService.SP_DM_TONGIAO_DEL(ma);

            if (results == 0)
            {
                return NotFound();
            }

            return Ok(new { message = "Xóa thành công!" });
        }
    }
}
