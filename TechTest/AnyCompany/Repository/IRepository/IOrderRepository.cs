﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnyCompany.Repository.IRepository
{
    public interface IOrderRepository
    {
        void Save(Order order);
    }
}
