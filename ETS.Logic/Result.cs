using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;


namespace ETS.Logic
{
    public enum ResultEnum
    {
        Success,
        Fail
    }
    public class Result<T>
    {
        
            public ResultEnum Status { get; set; }
            public T Data { get; set; }
      
    }
}
