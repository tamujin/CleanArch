using ErrorOr;
namespace BuberDinner.Domain.Common.Errors;

public static partial class Errors
{
    public static class Authentication
    {
        public static Error InvalidCredentials => Error.Validation(code: "Auth.InvalidCredential",
                                                                 description: "Invalid Credential.");
    }
}