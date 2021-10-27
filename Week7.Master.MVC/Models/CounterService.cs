using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Week7.Master.MVC.Models
{
    public class CounterService : ICounterService
    {
        private int count = 0;
        public int Count()
        {
            return ++count;
        }
    }
}
