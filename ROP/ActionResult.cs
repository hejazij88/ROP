using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ROP
{
    public class ActionResult
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }


        public static ActionResult<T> CreateValidator<T>(T param) =>
            new(param);

        public static ActionResult<T> Failure<T>(string message)
            => new(message);

        public static ActionResult<T> Success<T>(T data)
            => new(data);
    }
    public class ActionResult<T>:ActionResult
    {
        public T Data { get; set; }

        public ActionResult(string message)
        {
            Message=message;
            IsSuccess = false;
        }

        public ActionResult(T data)
        {
            IsSuccess = true;
            Data=data;
        }
    }

    public static class ResultExtension
    {
        public static ActionResult<T> Validate<T>(this ActionResult<T> actionResult,
            Func<T, bool> predict, string message)
        {
            if (!actionResult.IsSuccess)
            {
                return actionResult;
            }

            var predicateResult = predict(actionResult.Data);
            if (predicateResult)
            {
                return ActionResult.Failure<T>(message);
            }

            return actionResult;
        }
    }
}
