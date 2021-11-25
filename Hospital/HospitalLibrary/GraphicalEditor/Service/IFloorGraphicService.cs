using System.Collections.Generic;
using FluentResults;
using HospitalLibrary.GraphicalEditor.Model;
using Microsoft.VisualBasic.CompilerServices;

namespace HospitalLibrary.GraphicalEditor.Service
{
    public interface IFloorGraphicService
    {
        Result<IList<FloorGraphic>> GetFloorGraphics();
        Result<int> GetBuildingForRoom(int roomId);
    }
}
