﻿using ClientConvertisseurV3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientConvertisseurV3.Services
{
    public interface IService
    {
       Task<List<Devise>> GetDevisesAsync(string nomControleur);

    }
}
