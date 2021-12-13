using System.Collections.Generic;
using FluentResults;
using HospitalLibrary.GraphicalEditor.Model;
using Microsoft.VisualBasic.CompilerServices;

namespace HospitalLibrary.GraphicalEditor.Service
{
    public interface IFloorGraphicService
    {
        List<FloorGraphic> GetFloorGraphics();
        int GetBuildingForRoom(int roomId);
        RoomGraphic GetRoomGraphicByRoomId(int roomId);
    }
}
