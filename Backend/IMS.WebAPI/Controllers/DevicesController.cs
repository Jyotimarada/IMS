using IMS.Application.DTO;
using IMS.Application.Repositories;
using IMS.Application.Services;
using IMS.Domain.Entities;
using IMS.Infrastructure.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace IMS.WebAPI.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class DevicesController : ControllerBase
    {
        private readonly DeviceService _deviceService;
        private readonly ILogger<DevicesController> _logger;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="context"></param>
        public DevicesController(ILogger<DevicesController> logger, DeviceService deviceService)
        {
            _logger = logger;
            _deviceService = deviceService;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IEnumerable<DeviceDTO>> GetDevices([FromQuery] string? s,CancellationToken cancellationToken)
        {
            _logger.LogInformation("Get Devices logs working");
            return _deviceService.SearchByName(s, cancellationToken);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("{id:int}")]
        public async Task<ActionResult<Device>> GetDevice([FromRoute]  int id, CancellationToken cancellationToken)
        {
            var device = await  _deviceService.GetDevice(id, cancellationToken);
            return Ok(device);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="device"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> AddDevice([FromBody] DeviceDTO device, CancellationToken cancellationToken)
        {
            await _deviceService.AddDevice(device, cancellationToken);

            return Ok(new { Message = "Device created!" });
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="device"></param>
        /// <returns></returns>
        [HttpPatch]
        [Route("{id:int}")]
        public async Task<IActionResult> UpdateDevice([FromRoute] int id, [FromBody] DeviceDTO device, CancellationToken cancellationToken)
        {
            device.Id = id;
            await _deviceService.UpdateDevice(device, cancellationToken);

            return Ok(new { Message = "Device created!" });
        }


    }
}
