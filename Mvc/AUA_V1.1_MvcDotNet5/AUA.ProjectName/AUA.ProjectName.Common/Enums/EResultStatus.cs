using System.ComponentModel;

namespace AUA.ProjectName.Common.Enums
{
    public enum EResultStatus
    {
        [Description("The request has an error.")]
        HasError = 1,

        [Description("User not found.")]
        UserNotFind = 2,

        [Description("User is not active.")]
        UserNotActive = 3,

        [Description("The password is incorrect.")]
        InvalidPassword = 4,

        [Description("Username or password is incorrect.")]
        InValidUserNameOrPassword = 5,

        [Description("The submitted data is incorrect.")]
        InvalidData = 6,

        [Description("Username is empty.")]
        IsEmptyUserName = 7,

        [Description("Password is empty.")]
        IsEmptyPassword = 8,

        [Description("The access token in the request header is empty.")]
        TokenIsNull = 9,

        [Description("Dear user, you have not logged in.")]
        YouHaveNotLoggedIn = 10,

        [Description("Access is not allowed for your user(Access Denied).")]
        AccessDenied = 11,

        [Description("Token refresh is invalid.")]
        InvalidRefreshToken = 12,

        [Description("Access token time has expired.")]
        AccessTokenExpired = 13,

        [Description("The submitted model is not correct.")]
        InvalidModel = 14,

        [Description("Unspecified error.")]
        Exception = 15,

        [Description("The token refresh time has expired.")]
        RefreshTokenExpired = 16,

        [Description("Your user has been locked and you must log in again.")]
        LockedUser = 17,

        [Description("Error performing operations.")]
        ErrorOperations = 18,

        [Description("The user is active.")]
        UserIsActive = 19,



        [Description("Request executed successfully.")]
        Success = 200,
    }
}
