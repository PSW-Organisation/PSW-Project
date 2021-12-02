﻿using FluentResults;
using HospitalLibrary.GraphicalEditor.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace HospitalLibrary.GraphicalEditor.Service
{
    public interface IRoomGraphicService 
    {
        IList<RoomGraphic> GetRoomGraphics();
    }
}
