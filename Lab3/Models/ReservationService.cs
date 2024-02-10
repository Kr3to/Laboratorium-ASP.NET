using Data;
using Data.Entities;
using Laboratorium3_App.Mappers;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Laboratorium3_App.Models
{
    public class ReservationService : IReservationService
    {
        private AppDbContext _context;

        public ReservationService(AppDbContext context)
        {
            _context = context;
        }

        public int Add(Reservation reservation)
        {
            var e = _context.Reservations.Add(ReservationMapper.ToEntity(reservation));
            _context.SaveChanges();
            return e.Entity.Id;
        }

        public void Delete(int id)
        {
            ReservationEntity? find = _context.Reservations.Find(id);
            if ( find != null)
            {
                _context.Reservations.Remove(find);
            }
        }

        public void DeleteById(int id)
        {
            ReservationEntity? find = _context.Reservations.Find(id);
    
            if (find != null)
            {
                _context.Reservations.Remove(find);
                
                _context.SaveChanges();
            }
        }

        public List<Reservation>? FindAll()
        {
            return _context.Reservations.Select(e => ReservationMapper.FromEntity(e)).ToList(); ;
        }

        public Reservation? FindById(int id)
        {
            return ReservationMapper.FromEntity(_context.Reservations.Find(id));
        }

        public void Update(Reservation reservation)
        {
            _context.Reservations.Update(ReservationMapper.ToEntity(reservation));
            _context.SaveChanges();
        }

        void IReservationService.Add(Reservation reservation)
        {
            ReservationEntity entity = ReservationMapper.ToEntity(reservation);
            var addedEntity = _context.Reservations.Add(entity);
            _context.SaveChanges();

        }

        /* public List<OrganizationEntity> FindAllOrganizations()
        {
            return _context.Organizations.ToList();
        }

        public OrganizationEntity FindOrganizationById(int organizationId)
        {
            return _context.Organizations.FirstOrDefault(o => o.Id == organizationId);
        } */
    }
}