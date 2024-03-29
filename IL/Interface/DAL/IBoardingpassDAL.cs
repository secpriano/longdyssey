﻿using IL.DTO;

namespace IL.Interface.DAL
{
    public interface IBoardingpassDAL
    {
        public List<BoardingpassDTO> GetAll();
        public bool BookSeatFromFlight(long seat, long flightId, long userId);
        public List<BoardingpassDTO> GetBoardingpassesByFlightId(long id);
        public BoardingpassDTO GetById(long id);
        public bool Insert(BoardingpassDTO entity);
        public bool Update(BoardingpassDTO entity);
        public bool DeleteByID(long id);

    }
}
