using AutoMarket.Services.Abstracts;
using Microsoft.AspNetCore.Mvc;
using AutoMarket.DTOs.Response;
using AutoMarket.DTOs.Request;

namespace AutoMarket.Controllers;

/// <summary>
/// ���������� ��� ���������� ������������.
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class CarController(ICarService carService) : ControllerBase
{
    private readonly ICarService _carService = carService;

    #region [ Maker ]

    /// <summary>
    /// �������� ���� �������������� �����������.
    /// </summary>
    /// <returns>������ ���� ��������������.</returns>
    /// <remarks>
    /// ������ �������:
    ///
    ///     GET /api/Car/get-all-makers
    ///
    /// </remarks>
    [HttpGet("get-all-makers")]
    public async Task<ActionResult<IEnumerable<MakerResponse>>> GetAllMakers()
    {
        var makers = await _carService.GetAllMakersAsync();
        return Ok(makers);
    }

    /// <summary>
    /// �������� ������������� �� ��������������.
    /// </summary>
    /// <param name="request">������, ���������� ������������� �������������.</param>
    /// <returns>���������� � �������������.</returns>
    /// <remarks>
    /// ������ �������:
    ///
    ///     GET /api/Car/get-maker?id={id}
    ///
    /// </remarks>
    [HttpGet("get-maker")]
    public async Task<ActionResult<MakerResponse>> GetMakerById([FromQuery] DeleteMakerRequest request)
    {
        var maker = await _carService.GetMakerByIdAsync(request.Id);

        if (maker is null)
            return NotFound();

        return Ok(maker);
    }

    /// <summary>
    /// �������� ������ �������������.
    /// </summary>
    /// <param name="request">������ �� �������� ������ �������������.</param>
    /// <returns>�������� ��������.</returns>
    /// <remarks>
    /// ������ �������:
    ///
    ///     POST /api/Car/add-maker?name={name}&country={country}&foundedYear={foundedYear}
    ///
    /// </remarks>
    [HttpPost("add-maker")]
    public async Task<ActionResult> AddMaker(CreateMakerRequest request)
    {
        var createdMaker = await _carService.AddMakerAsync(request);
        return NoContent();
    }

    /// <summary>
    /// �������� ���������� � �������������.
    /// </summary>
    /// <param name="request">������ �� ���������� ���������� � �������������.</param>
    /// <returns>�������� ����������.</returns>
    /// <remarks>
    /// ������ �������:
    ///
    ///     PUT /api/Car/update-maker?id={id}&name={name}&country={country}&foundedYear={foundedYear}
    ///
    /// </remarks>
    [HttpPut("update-maker")]
    public async Task<ActionResult> UpdateMaker(UpdateMakerRequest request)
    {
        await _carService.UpdateMakerAsync(request);
        return NoContent();
    }

    /// <summary>
    /// ������� �������������.
    /// </summary>
    /// <param name="request">������ �� �������� �������������.</param>
    /// <returns>�������� ��������.</returns>
    /// <remarks>
    /// ������ �������:
    ///
    ///     DELETE /api/Car/delete-maker?id={id}
    ///
    /// </remarks>
    [HttpDelete("delete-maker")]
    public async Task<ActionResult> DeleteMaker([FromQuery] DeleteMakerRequest request)
    {
        await _carService.DeleteMakerAsync(request.Id);
        return NoContent();
    }

    #endregion

    #region [ Model ]

    /// <summary>
    /// �������� ������ ���������� �� ��������������.
    /// </summary>
    /// <param name="request">������, ���������� ������������� ������ ����������.</param>
    /// <returns>���������� � ������.</returns>
    /// <remarks>
    /// ������ �������:
    ///
    ///     GET /api/Car/get-model?id={id}
    ///
    /// </remarks>
    [HttpGet("get-model")]
    public async Task<ActionResult<ModelResponse>> GetModelById([FromQuery] DeleteModelRequest request)
    {
        var model = await _carService.GetModelByIdAsync(request.Id);

        if (model is null)
            return NotFound();

        return Ok(model);
    }

    /// <summary>
    /// �������� ����� ������ ����������.
    /// </summary>
    /// <param name="request">������ �� �������� ����� ������ ����������.</param>
    /// <returns>�������� ��������.</returns>
    /// <remarks>
    /// ������ �������:
    ///
    ///     POST /api/Car/add-model?name={name}&releaseYear={releaseYear}&makerId={makerId}
    ///
    /// </remarks>
    [HttpPost("add-model")]
    public async Task<ActionResult> AddModel(CreateModelRequest request)
    {
        var createdModel = await _carService.AddModelAsync(request);
        return CreatedAtAction(nameof(GetModelById), new { id = createdModel.Id });
    }

    /// <summary>
    /// �������� ���������� � ������ ����������.
    /// </summary>
    /// <param name="request">������ �� ���������� ���������� � ������ ����������.</param>
    /// <returns>�������� ����������.</returns>
    /// <remarks>
    /// ������ �������:
    ///
    ///     PUT /api/Car/update-model?id={id}&name={name}&releaseYear={releaseYear}&makerId={makerId}
    ///
    /// </remarks>
    [HttpPut("update-model")]
    public async Task<ActionResult> UpdateModel(UpdateModelRequest request)
    {
        await _carService.UpdateModelAsync(request);
        return NoContent();
    }

    /// <summary>
    /// ������� ������ ����������.
    /// </summary>
    /// <param name="request">������ �� �������� ������ ����������.</param>
    /// <returns>�������� ��������.</returns>
    /// <remarks>
    /// ������ �������:
    ///
    ///     DELETE /api/Car/delete-model?id={id}
    ///
    /// </remarks>
    [HttpDelete("delete-model")]
    public async Task<ActionResult> DeleteMaker([FromQuery] DeleteModelRequest request)
    {
        await _carService.DeleteModelAsync(request.Id);
        return NoContent();
    }

    #endregion
}