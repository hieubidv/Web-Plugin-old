
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ICreative.Infrastructure.Domain;
using ICreative.Infrastructure.UnitOfWork;
using ICreative.Model;
using ICreative.Services.Interfaces;
using ICreative.Services.Mapping;
using ICreative.Services.Messaging;
using ICreative.Services.ViewModels;
namespace ICreative.Services.Implementations
{
    public class RoomService : IRoomService
    {
        private readonly IRoomRepository _roomRepository;
        private readonly IUnitOfWork _uow;

        public RoomService(IRoomRepository roomRepository,
                               IUnitOfWork uow)
        {
            _roomRepository = roomRepository;
            _uow = uow;
        }

        public CreateRoomResponse CreateRoom(CreateRoomRequest request)
        {
            CreateRoomResponse response = new CreateRoomResponse();
            Room room = new Room();

                  room.RoomName = request.RoomName;	
                  room.Address = request.Address;	
                  room.PhoneNumber = request.PhoneNumber;	
                  room.Users = request.Users.ConvertToUsers();

            if (room.GetBrokenRules().Count() > 0)
            {
                response.Errors = room.GetBrokenRules().ToList();
            }
            else
            {
               try {
        	    _roomRepository.Add(room);
	            _uow.Commit();  
                    response.Errors = new List<BusinessRule>();
               } catch (Exception ex)
               {
                    List<BusinessRule> errors = new List<BusinessRule>();                    
                    do
                    {
                            errors.Add(new BusinessRule("DAL", "DAL_ERROR: " + ex.Message));
                            ex = ex.InnerException;
                    } while (ex != null);

                    response.Errors = errors;
               }
            } 

            return response;
        }


        public GetRoomResponse GetRoom(GetRoomRequest request)
        {
            GetRoomResponse response = new GetRoomResponse();

            Room room = _roomRepository
                                     .FindBy(request.RoomId);

            if (room != null)
            {
                response.RoomFound = true;
                response.Room = room.ConvertToRoomView();
            }
            else
                response.RoomFound = false;


            return response;
        }

        public ModifyRoomResponse ModifyRoom(ModifyRoomRequest request)
        {
            ModifyRoomResponse response = new ModifyRoomResponse();

            Room room = _roomRepository
                                         .FindBy(request.RoomId);

               room.Id = request.RoomId;
                  room.RoomName = request.RoomName;	
                  room.Address = request.Address;	
                  room.PhoneNumber = request.PhoneNumber;	
                  room.Users = request.Users.ConvertToUsers();


            if (room.GetBrokenRules().Count() > 0)
            {
                response.Errors = room.GetBrokenRules().ToList();
            }
            else
            {
                try {
  	                _roomRepository.Save(room);
        	        _uow.Commit();
                        response.Errors = new List<BusinessRule>();
                } catch (Exception ex)
                {
	            response.Errors = new List<BusinessRule>();
                    response.Errors.Add(new BusinessRule("DAL", "DAL_ERROR: " + ex.Message));
                }                           
            }           


            return response;
        }
        
        public GetAllRoomResponse GetAllRooms()
        {
            GetAllRoomResponse response = new GetAllRoomResponse();

            IEnumerable<Room> rooms = _roomRepository
                                     .FindAll();

            if (rooms != null)
            {
                response.RoomFound = true;
                response.Rooms = rooms.ConvertToRoomViews();   
            }
            else
                response.RoomFound = false;


            return response;
        } 
        
        
        public RemoveRoomResponse RemoveRoom(RemoveRoomRequest request)
        {
            RemoveRoomResponse response = new RemoveRoomResponse();
            response.Errors = new List<BusinessRule>();
            try {
	            if (_roomRepository.Remove(request.RoomId) > 0)
	            {
        	        response.RoomDeleted = true;
	            }
           } catch (Exception ex)
           {
                    response.Errors.Add(new BusinessRule("DAL", "DAL_ERROR: " + ex.Message));
           }
            return response;
        }
        
    }
}
