using ehealthcare.Model;
using FluentResults;
using System;
using System.Collections.Generic;
using System.Text;

namespace HospitalLibrary.GraphicalEditor.Service
{
    public interface IRoomGraphicService 
    {
        Result<IList<RoomGraphic>> GetRoomGraphics();
    }
}
