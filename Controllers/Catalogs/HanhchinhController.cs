using Microsoft.AspNetCore.Mvc;
using WebAPINetCore.Services;

namespace WebAPINetCore.Controllers.Catalogs
{
    [Route("api/dm/hanh-chinh")]
    [ApiController]
    public class HanhchinhController : BaseController
    {
        private readonly IHanhchinhService _hanhchinhService;

        public HanhchinhController(IHanhchinhService hanhchinhService)
        {
            this._hanhchinhService = hanhchinhService;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet("tinh")]
        public IActionResult GetDMTinh()
        {
            var tinh = _hanhchinhService.SP_DM_TINH();

            if (tinh == null)
            {
                return NotFound();
            }

            return Ok(tinh);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ma"></param>
        /// <returns></returns>
        [HttpGet("tinh/{ma}")]
        public IActionResult GetDMTinhByMa(string ma)
        {
            var tinh = _hanhchinhService.SP_DM_TINH_MA(ma);

            if (tinh == null)
            {
                return NotFound();
            }

            return Ok(tinh);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="matinh"></param>
        /// <returns></returns>
        [HttpGet("huyen_matinh/{matinh}")]
        public IActionResult GetDMHuyen(string matinh)
        {
            var huyens = _hanhchinhService.SP_DM_HUYEN_MATINH(matinh);

            if (huyens == null)
            {
                return NotFound();
            }

            return Ok(huyens);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ma"></param>
        /// <returns></returns>
        [HttpGet("huyen/{ma}")]
        public IActionResult GetDMHuyenByMa(string ma)
        {
            var huyen = _hanhchinhService.SP_DM_HUYEN_MA(ma);

            if (huyen == null)
            {
                return NotFound();
            }

            return Ok(huyen);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ma"></param>
        /// <returns></returns>
        [HttpGet("phuongxa/{ma}")]
        public IActionResult GetDMPhuongXaByMa(string ma)
        {
            var phuong = _hanhchinhService.SP_DM_PHUONGXA_MA(ma);

            if (phuong == null)
            {
                return NotFound();
            }

            return Ok(phuong);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ma"></param>
        /// <returns></returns>
        [HttpGet("phuongxa_mahuyen/{mahuyen}")]
        public IActionResult GetDMPhuongXaByMaHuyen(string mahuyen)
        {
            var phuongs = _hanhchinhService.SP_DM_PHUONGXA_MAHUYEN(mahuyen);

            if (phuongs == null)
            {
                return NotFound();
            }

            return Ok(phuongs);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="matinh"></param>
        /// <returns></returns>
        [HttpGet("phuongxa_matinh/{matinh}")]
        public IActionResult GetDMPhuongXaByMaTinh(string matinh)
        {
            var phuongs = _hanhchinhService.SP_DM_PHUONGXA_MATINH(matinh);

            if (phuongs == null)
            {
                return NotFound();
            }

            return Ok(phuongs);
        }
    }
}
