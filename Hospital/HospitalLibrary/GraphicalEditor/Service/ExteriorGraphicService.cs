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
        private readonly IExteriorGraphicRepository _exteriorGraphicRepository;
        
        public ExteriorGraphicService(IExteriorGraphicRepository exteriorGraphicRepository)
        {
            _exteriorGraphicRepository = exteriorGraphicRepository;
        }

        public IList<ExteriorGraphic> GetExteriorGraphics()
        {
            return _exteriorGraphicRepository.GetAll();
        }
    }
}




