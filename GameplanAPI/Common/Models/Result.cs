using FluentValidation.Results;

namespace GameplanAPI.Common.Models
{
    public class Result
    {
        protected Result(
            bool isSuccess,
            Error error)
        {
            if (isSuccess && error != Error.None ||
                !isSuccess && error == Error.None)
            {
                throw new ArgumentException("Invalid error", nameof(error));
            }

            IsSuccess = isSuccess;
            Error = error;
        }

        protected Result(
            bool isSuccess,
            IEnumerable<ValidationFailure> validationErrors)
        {
            if (isSuccess && validationErrors.Any() ||
                !isSuccess && !validationErrors.Any())
            {
                throw new ArgumentException("Invalid error", nameof(validationErrors));
            }

            IsSuccess = isSuccess;
            ValidationErrors = validationErrors;
        }

        public bool IsSuccess { get; }

        public bool IsFailure => !IsSuccess;

        public Error Error { get; } = Error.None;

        public IEnumerable<ValidationFailure> ValidationErrors { get; } = Enumerable.Empty<ValidationFailure>();

        public static Result Success() => new(true, Error.None);

        public static Result Failure(Error error) => new(false, error);

        public static Result Failure(IEnumerable<ValidationFailure> validationErrors) => new(false, validationErrors);
    }

    public class Result<TValue> : Result
    {
        private Result(TValue? value,
            bool isSuccess,
            Error error)
            : base(isSuccess, error)
        {
            if (!isSuccess && value != null)
            {
                throw new ArgumentException("Invalid error", nameof(error));
            }

            Value = value;
        }

        protected Result(
            TValue? value,
            bool isSuccess,
            IEnumerable<ValidationFailure> validationErrors)
            : base(isSuccess, validationErrors)
        {
            if (!isSuccess && value != null)
            {
                throw new ArgumentException("Invalid error", nameof(validationErrors));
            }

            Value = value;
        }

        public TValue? Value { get; }

        public static Result<TValue> Success(TValue value) => new(value, true, Error.None);

        public static new Result<TValue> Failure(Error error) => new(default, false, error);

        public static new Result<TValue> Failure(IEnumerable<ValidationFailure> validationErrors) => new(default, false, validationErrors);
    }
}
