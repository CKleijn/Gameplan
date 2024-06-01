using GameplanAPI.Common.Models;

namespace GameplanAPI.Common.Extensions
{
    public static class ResultExtensions
    {
        public static IResult GetProblemDetails(this Result result)
        {
            if (result.IsSuccess)
            {
                throw new InvalidOperationException("Can't convert success result to problem details");
            }

            object[] errors = result.Error != Error.None
                ? new[] { result.Error }
                : result.ValidationErrors
                    .Select(err => err.ErrorMessage)
                    .ToArray();

            return Results.Problem(
                    statusCode: StatusCodes.Status400BadRequest,
                    title: "Bad Request",
                    extensions: new Dictionary<string, object?>
                    {
                        { "errors", errors }
                    });
        }
    }
}
