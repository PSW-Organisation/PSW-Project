using System.Collections.Generic;
using FluentResults;
using HospitalLibrary.GraphicalEditor.Model;

namespace HospitalLibrary.GraphicalEditor.Service
{
    public interface IFloorGraphicService
    {
        Result<IList<FloorGraphic>> GetFloorGraphics();
    }
}
