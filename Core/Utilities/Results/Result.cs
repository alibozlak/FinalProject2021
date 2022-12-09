using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Results
{
    public class Result : IResult
    {
		private bool isSuccess;
		public bool IsSuccess
		{
			get { return isSuccess; }
		}

		private string message;
		public string Message
		{
			get { return message; }
		}

		// Getter'lar constructorda set edilebilir !
        public Result(bool isSuccess, string message) : this(isSuccess)
        {
            this.message = message;
        }

        public Result(bool isSuccess)
        {
            this.isSuccess = isSuccess;
        }
    }
}
