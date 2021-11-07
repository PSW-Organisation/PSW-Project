using System;
using System.Collections.Generic;
using System.Text;
using ehealthcare.Model;
using FluentResults;
using HospitalLibrary.GraphicalEditor.Model;

namespace HospitalLibrary.GraphicalEditor.Service
{
    public interface IExteriorGraphicService
    {
        Result<List<ExteriorGraphic>> GetExteriorGraphics();
    }
}
