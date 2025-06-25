// UnitOfWork.cs
using HIV_CARE.Repositories.ThienTTT.DBContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HIV_CARE.Repositories.ThienTTT
{
    public interface IUnitOfWork : IDisposable
    {
        SystemUserAccountRepository SystemUserAccountRepository { get; }
        AppointmentThienTttRepository AppointmentThienTttRepository { get; }
        DoctorPhatNhRepository DoctorPhatNhRepository { get; }


        int SaveChangesWithTransaction();
        Task<int> SaveChangesWithTransactionAsync();
    }

    public class UnitOfWork : IUnitOfWork
    {
        private readonly SU25_PRN232_SE1725_G4_HIVcareContext _context;
        private SystemUserAccountRepository _systemUserAccountRepository;
        private AppointmentThienTttRepository _appointmentThienTttRepository;
        private DoctorPhatNhRepository _doctorPhatNhRepository;


        public UnitOfWork() => _context ??= new SU25_PRN232_SE1725_G4_HIVcareContext();

        public SystemUserAccountRepository SystemUserAccountRepository
        {
            get { return _systemUserAccountRepository ??= new SystemUserAccountRepository(_context); }
        }
        public AppointmentThienTttRepository AppointmentThienTttRepository
        {
            get { return _appointmentThienTttRepository ??= new AppointmentThienTttRepository(_context); }
        }
        public DoctorPhatNhRepository DoctorPhatNhRepository
        {
            get { return _doctorPhatNhRepository ??= new DoctorPhatNhRepository(_context); }
        }

        public void Dispose() => _context.Dispose();

        public int SaveChangesWithTransaction()
        {
            int result = -1;

            //System.Data.IsolationLevel.Snapshot
            using (var dbContextTransaction = _context.Database.BeginTransaction())
            {
                try
                {
                    result = _context.SaveChanges();
                    dbContextTransaction.Commit();
                }
                catch (Exception)
                {
                    //Log Exception Handling message                      
                    result = -1;
                    dbContextTransaction.Rollback();
                }
            }

            return result;
        }

        public async Task<int> SaveChangesWithTransactionAsync()
        {
            int result = -1;

            //System.Data.IsolationLevel.Snapshot
            using (var dbContextTransaction = _context.Database.BeginTransaction())
            {
                try
                {
                    result = await _context.SaveChangesAsync();
                    dbContextTransaction.Commit();
                }
                catch (Exception)
                {
                    //Log Exception Handling message                      
                    result = -1;
                    dbContextTransaction.Rollback();
                }
            }

            return result;
        }
    }
}
