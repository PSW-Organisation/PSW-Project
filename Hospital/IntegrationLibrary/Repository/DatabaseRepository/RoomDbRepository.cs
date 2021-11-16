﻿using System;
using System.Collections.Generic;
using System.Text;
using IntegrationLibrary.Repository;
using IntegrationLibrary.Model;
namespace IntegrationLibrary.Repository.DatabaseRepository
{
    public class RoomDbRepository : GenericDatabaseRepository<Room>, RoomRepository

    {
        public RoomDbRepository(IntegrationDbContext dbContext) : base(dbContext) { }
    }
}
