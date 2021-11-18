using FluentResults;
using HospitalLibrary.GraphicalEditor.Model;
using HospitalLibrary.GraphicalEditor.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace HospitalLibrary.GraphicalEditor.Service
{
    public class ExteriorGraphicService : IExteriorGraphicService
    {
        private IExteriorGraphicRepository _exteriorGraphicRepository;
        public ExteriorGraphicService(IExteriorGraphicRepository exteriorGraphicRepository)
        {
            _exteriorGraphicRepository = exteriorGraphicRepository;
        }

        public Result<IList<ExteriorGraphic>> GetExteriorGraphics()
        {
            return Result.Ok(_exteriorGraphicRepository.GetAll());
        }
    }
}




