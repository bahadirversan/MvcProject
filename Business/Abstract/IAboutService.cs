﻿using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IAboutService
    {
        List<About> GetAboutList();
        void AddAbout(About about);
        About GetById(int id);
        void DeleteAbout(About about);
        void UpdateAbout(About about);
    }
}
