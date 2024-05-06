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
        /// DevicesController
        /// </summary>
        /// <param name="logger">logger</param>
        /// <param name="deviceService">device service</param>
        public DevicesController(ILogger<DevicesController> logger, DeviceService deviceService)
        {
            _logger = logger;
            _deviceService = deviceService;
        }

        /// <summary>
        /// Get Devices which contains the search string
        /// </summary>
        /// <param name="s">search string</param>
        /// <returns>Devices matching the search string</returns>
        [HttpGet]
        public async Task<IEnumerable<DeviceDTO>> GetDevices([FromQuery] string? s, [FromQuery] bool availableDevices, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Get Devices logs working");
            return _deviceService.SearchByName(s, availableDevices, cancellationToken);
        }

        /// <summary>
        /// Get device by id
        /// </summary>
        /// <param name="id"> Id of the device</param>
        /// <returns>Device matching the id</returns>
        [HttpGet]
        [Route("{id:int}")]
        public async Task<ActionResult<Device>> GetDevice([FromRoute]  int id, CancellationToken cancellationToken)
        {
            var device = await  _deviceService.GetDevice(id, cancellationToken);
            return Ok(device);
        }

        /// <summary>
        /// Add device
        /// </summary>
        /// <param name="device">Device DeviceDTO object for adding</param>
        /// <returns>Result of the add operation</returns>
        [HttpPost]
        public async Task<IActionResult> AddDevice([FromBody] DeviceDTO device, CancellationToken cancellationToken)
        {
            await _deviceService.AddDevice(device, cancellationToken);

            return Ok(new { Message = "Device created!" });
        }

        /// <summary>
        /// Update device with id
        /// </summary>
        /// <param name="id">Device id to be updated</param>
        /// <returns>Result of the update operation</returns>
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
