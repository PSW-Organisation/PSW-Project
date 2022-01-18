using ehealthcare.Model;
using HospitalLibrary.Events.Model;
using HospitalLibrary.Repository.DbRepository;
using System;
using System.Collections.Generic;
using System.Text;

namespace HospitalLibrary.Events.Repository
{
    public class EventRepository : GenericDbRepository<Event>, IEventRepository
    {

        private readonly HospitalDbContext _dbContext;
        public EventRepository(HospitalDbContext dbContext) : base(dbContext)
        {
            this._dbContext = dbContext;
        }






    }




}
