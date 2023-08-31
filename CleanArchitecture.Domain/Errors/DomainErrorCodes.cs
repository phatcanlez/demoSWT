namespace CleanArchitecture.Domain.Errors;

public static class DomainErrorCodes
{
    public static class User
    {
        // User Validation
        public const string UserEmptyId = "USER_EMPTY_ID";
        public const string UserEmptyFirstName = "USER_EMPTY_FIRST_NAME";
        public const string UserEmptyLastName = "USER_EMPTY_LAST_NAME";
        public const string UserEmailExceedsMaxLength = "USER_EMAIL_EXCEEDS_MAX_LENGTH";
        public const string UserFirstNameExceedsMaxLength = "USER_FIRST_NAME_EXCEEDS_MAX_LENGTH";
        public const string UserLastNameExceedsMaxLength = "USER_LAST_NAME_EXCEEDS_MAX_LENGTH";
        public const string UserInvalidEmail = "USER_INVALID_EMAIL";
        public const string UserInvalidRole = "USER_INVALID_ROLE";

        // User Password Validation
        public const string UserEmptyPassword = "USER_PASSWORD_MAY_NOT_BE_EMPTY";
        public const string UserShortPassword = "USER_PASSWORD_MAY_NOT_BE_SHORTER_THAN_6_CHARACTERS";
        public const string UserLongPassword = "USER_PASSWORD_MAY_NOT_BE_LONGER_THAN_50_CHARACTERS";
        public const string UserUppercaseLetterPassword = "USER_PASSWORD_MUST_CONTAIN_A_UPPERCASE_LETTER";
        public const string UserLowercaseLetterPassword = "USER_PASSWORD_MUST_CONTAIN_A_LOWERCASE_LETTER";
        public const string UserNumberPassword = "USER_PASSWORD_MUST_CONTAIN_A_NUMBER";
        public const string UserSpecialCharPassword = "USER_PASSWORD_MUST_CONTAIN_A_SPECIAL_CHARACTER";

        // General
        public const string UserAlreadyExists = "USER_ALREADY_EXISTS";
        public const string UserPasswordIncorrect = "USER_PASSWORD_INCORRECT";
    }

    public static class Tenant
    {
        // Tenant Validation
        public const string TenantEmptyId = "TENANT_EMPTY_ID";
        public const string TenantEmptyName = "TENANT_EMPTY_NAME";
        public const string TenantNameExceedsMaxLength = "TENANT_NAME_EXCEEDS_MAX_LENGTH";

        // General
        public const string TenantAlreadyExists = "TENANT_ALREADY_EXISTS";
    }
}