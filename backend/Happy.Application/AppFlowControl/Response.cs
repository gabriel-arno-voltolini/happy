using FluentValidation.Results;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Happy.Application.AppFlowControl
{
    public class Response
    {
        public bool Success => !Errors.Any();
        public List<string> Errors { get; set; }

        public Response()
        {
            Errors = new List<string>();
        }

        public void SetErrorsList(IList<ValidationFailure> errors)
        {
            errors.ToList().ForEach(err => Errors.Add(err.ToString()));
        }

        public string GetErrorMessage()
        {
            var builder = new StringBuilder();

            foreach (string item in this.Errors)
            {
                builder.Append(item);
            }
            return builder.ToString();
        }
    }
}
