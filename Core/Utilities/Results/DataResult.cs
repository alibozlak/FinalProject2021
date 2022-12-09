using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Results
{
    public class DataResult<T> : Result, IDataResult<T>
    {
		private T data;
        public T Data
		{
			get { return data; }
		}

        public DataResult(bool isSuccess, string message, T data) : base(isSuccess, message) 
        {
            this.data = data;
        }

        public DataResult(bool isSuccess, T data) : base(isSuccess)
        {
            this.data= data;
        }
    }
}
