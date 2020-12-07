
using Microsoft.EntityFrameworkCore;
using Sysplan.Agrimaldo.Domain.Interfaces.Repositories;
using Sysplan.Agrimaldo.Domain.Models;
using Sysplan.Agrimaldo.Infra.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Sysplan.Agrimaldo.Infra.Repositories
{
    public class SysplanAgrimaldoRepository : IDisposable, IRepository
    {
        private readonly SysplanAgrimaldoDatabase sysplanAgrimaldoDatabase;
        public SysplanAgrimaldoRepository(SysplanAgrimaldoDatabase _sysplanAgrimaldoDatabase)
        {
            sysplanAgrimaldoDatabase = _sysplanAgrimaldoDatabase;
        }
        public ReturnStructure<T> Add<T>(T obj) where T : class
        {
            sysplanAgrimaldoDatabase.Database.BeginTransaction();
            try
            {
                sysplanAgrimaldoDatabase.Set<T>().Add(obj);
            }
            catch (Exception ex)
            {
                sysplanAgrimaldoDatabase.Database.RollbackTransaction();
                return ReturnStructure<T>.Return(false, ex.Message);
            }

            sysplanAgrimaldoDatabase.Database.CommitTransaction();
            sysplanAgrimaldoDatabase.SaveChanges();
            return ReturnStructure<T>.Return(obj);
        }
        public ReturnStructure<T> Update<T>(T obj) where T : class
        {
            sysplanAgrimaldoDatabase.Database.BeginTransaction();
            try
            {
                sysplanAgrimaldoDatabase.Set<T>().Update(obj);
            }
            catch (Exception ex)
            {
                sysplanAgrimaldoDatabase.Database.RollbackTransaction();
                return ReturnStructure<T>.Return(false, ex.Message);
            }

            sysplanAgrimaldoDatabase.Database.CommitTransaction();
            sysplanAgrimaldoDatabase.SaveChanges();
            return ReturnStructure<T>.Return(obj);
        }
        public ReturnStructure<T> Delete<T>(T obj) where T : class
        {
            sysplanAgrimaldoDatabase.Database.BeginTransaction();
            try
            {
                sysplanAgrimaldoDatabase.Set<T>().Remove(obj);
            }
            catch (Exception ex)
            {
                sysplanAgrimaldoDatabase.Database.RollbackTransaction();
                return ReturnStructure<T>.Return(false, ex.Message);
            }

            sysplanAgrimaldoDatabase.Database.CommitTransaction();
            sysplanAgrimaldoDatabase.SaveChanges();
            return ReturnStructure<T>.Return(obj);
        }
        public T GetOne<T>(bool lazyLoading = false, Expression<Func<T, bool>> conditional = null) where T : class
        {
            if (conditional == null)
                conditional = p => true;

            return lazyLoading ? sysplanAgrimaldoDatabase.Set<T>().Where(conditional).FirstOrDefault() : sysplanAgrimaldoDatabase.Set<T>().Where(conditional).AsNoTracking().FirstOrDefault();
        }
        public T GetOne<T>(bool lazyLoading, Expression<Func<T, bool>> conditional, params Expression<Func<T, object>>[] includes) where T : class
        {
            if (conditional == null)
                conditional = p => true;

            var _result = sysplanAgrimaldoDatabase.Set<T>().Where(conditional);

            foreach (var include in includes)
                _result = _result.Include(include);

            return lazyLoading ? _result.FirstOrDefault() : _result.AsNoTracking().FirstOrDefault();
        }
        public List<T> List<T>(bool lazyLoading = false, Expression<Func<T, bool>> conditional = null) where T : class
        {
            if (conditional == null)
                conditional = p => true;

            return lazyLoading ? sysplanAgrimaldoDatabase.Set<T>().Where(conditional).ToList() : sysplanAgrimaldoDatabase.Set<T>().Where(conditional).AsNoTracking().ToList();
        }
        public List<T> List<T>(bool lazyLoading, Expression<Func<T, bool>> conditional, params Expression<Func<T, object>>[] includes) where T : class
        {
            if (conditional == null)
                conditional = p => true;

            var _result = sysplanAgrimaldoDatabase.Set<T>().Where(conditional);

            foreach (var include in includes)
                _result = _result.Include(include);

            return lazyLoading ? _result.ToList() : _result.AsNoTracking().ToList();
        }

        #region Dispose
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private bool _disposed;

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    sysplanAgrimaldoDatabase.Dispose();
                }
            }

            _disposed = true;
        }
        #endregion
    }
}
