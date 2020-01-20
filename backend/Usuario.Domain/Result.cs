using System.Collections.Generic;

namespace Usuario.Domain
{
    public class Result
    {
        public object data { get; set; }
        private List<string> _errors;
        public List<string> errors => _errors;
        public bool hasErrors => _errors.Count > 0;

        public Result() =>
            _errors = new List<string>();

        public void AddError(string error) =>
            _errors.Add(error);

    }
}
