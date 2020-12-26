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
    [Route("api/dm/huan-huy-chuong")]
    [ApiController]
    public class HuanhuychuongController : BaseController
    {
        private IHuanhuychuongService _huanhuychuongService;
        public HuanhuychuongController(IHuanhuychuongService huanhuychuongService)
        {
            _huanhuychuongService = huanhuychuongService;
        }

        [HttpGet("")]
        public IActionResult GetAll()
        {
            var HUANHUYCHUONGs = _huanhuychuongService.SP_DM_HUANHUYCHUONG();

            if (HUANHUYCHUONGs == null)
            {
                return NotFound();
            }

            return Ok(HUANHUYCHUONGs);
        }

        [HttpGet("ma/{id:int}")]
        public IActionResult Get(int id)
        {
            var HUANHUYCHUONG = _huanhuychuongService.SP_DM_HUANHUYCHUONG_ID(id);

            if (HUANHUYCHUONG == null)
            {
                return NotFound();
            }

            return Ok(HUANHUYCHUONG);
        }

        [HttpGet("trang-thai/{trangthai:int}")]
        public IActionResult GetMulti(int trangthai)
        {
            var HUANHUYCHUONGs = _huanhuychuongService.SP_DM_HUANHUYCHUONG_TRANGTHAI(trangthai);

            if (HUANHUYCHUONGs == null)
            {
                return NotFound();
            }

            return Ok(HUANHUYCHUONGs);
        }

        [HttpPost("cap-nhat-trang-thai")]
        public IActionResult Toggle([FromBody] JsonElement content)
        {
            int id = content.GetProperty("id").GetInt16();
            int trangthai = content.GetProperty("trangthai").GetInt16();

            int results = _huanhuychuongService.SP_DM_HUANHUYCHUONG_CAPNHAT_TRANGTHAI(id, trangthai);

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

            int results = _huanhuychuongService.SP_DM_HUANHUYCHUONG_INS(prmdata);

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

            int results = _huanhuychuongService.SP_DM_HUANHUYCHUONG_UPD(prmdata);

            if (results == 0)
            {
                return NotFound();
            }

            return Ok(new { message = "Thêm mới thành công!" });
        }

        [HttpPost("xoa/{id:int}")]
        public IActionResult Delete(int id)
        {
            int results = _huanhuychuongService.SP_DM_HUANHUYCHUONG_DEL(id);

            if (results == 0)
            {
                return NotFound();
            }

            return Ok(new { message = "Xóa thành công!" });
        }
    }
}
