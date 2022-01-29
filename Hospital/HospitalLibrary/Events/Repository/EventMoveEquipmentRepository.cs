using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ehealthcare.Model;
using HospitalLibrary.Events.Model;
using HospitalLibrary.Repository.DbRepository;

namespace HospitalLibrary.Events.Repository
{
    public class EventMoveEquipmentRepository : GenericDbRepository<EventMoveEquipment>, IEventMoveEquipmentRepository
    {

    private readonly HospitalDbContext _dbContext;
    public EventMoveEquipmentRepository(HospitalDbContext dbContext) : base(dbContext)
    {
        this._dbContext = dbContext;
    }

    public List<EventMoveEquipmentActions> GetActionsForManager(string idUser)
    {
        List<EventMoveEquipmentActions> moveEquipment = _dbContext.MoveEquipmentEvents.ToList()
            .GroupBy(q =>
                new
                {
                    q.NameOfEquipment,
                    q.IdUser,
                    q.SourceRoomID,
                    q.DestinationRoomID
                })
            .Where(q => q.Select(e => e.IdUser == idUser) != null)
            .Select(q => new EventMoveEquipmentActions()
            {
                NameOfEquipment = q.Key.NameOfEquipment,
                SourceRoomID =
                    q.FirstOrDefault(e => e.NameOfEquipment == q.Key.NameOfEquipment && e.IdUser.Equals(idUser))
                        .SourceRoomID,
                DestinationRoomID =
                    q.FirstOrDefault(e => e.NameOfEquipment == q.Key.NameOfEquipment && e.IdUser.Equals(idUser))
                        .DestinationRoomID,
                NumberOfEvents = q.Count()
            }).ToList();
        return moveEquipment;
    }
    }
}
