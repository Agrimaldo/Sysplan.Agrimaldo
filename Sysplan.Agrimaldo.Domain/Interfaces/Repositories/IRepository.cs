
using Sysplan.Agrimaldo.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Sysplan.Agrimaldo.Domain.Interfaces.Repositories
{
    public interface IRepository
    {
        ReturnStructure<T> Add<T>(T obj) where T : class;
        ReturnStructure<T> Update<T>(T obj) where T : class;
        ReturnStructure<T> Delete<T>(T obj) where T : class;
        T GetOne<T>(bool lazyLoading = false, Expression<Func<T, bool>> conditional = null) where T : class;
        T GetOne<T>(bool lazyLoading, Expression<Func<T, bool>> conditional, params Expression<Func<T, object>>[] includes) where T : class;
        List<T> List<T>(bool lazyLoading = false, Expression<Func<T, bool>> conditional = null) where T : class;
        List<T> List<T>(bool lazyLoading, Expression<Func<T, bool>> conditional, params Expression<Func<T, object>>[] includes) where T : class;
    }
}
