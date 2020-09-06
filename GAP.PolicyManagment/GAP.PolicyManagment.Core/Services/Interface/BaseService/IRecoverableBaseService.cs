﻿using System.Collections.Generic;

namespace GAP.PolicyManagment.Core.Services.Interface.BaseService
{
    public interface IRecoverableBaseService<TEntity> where TEntity : class
    {
        TEntity Get(object code);

        IEnumerable<TEntity> Get(TEntity entity);
    }   
}
