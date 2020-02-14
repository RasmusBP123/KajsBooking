using Microsoft.AspNetCore.Authorization;

namespace Infrastructure.Identity
{
    public static class Policies
    {
        public const string IsTeacher = "TEACHER";
        public const string IsStudent = "STUDENT";

        public static AuthorizationPolicy IsTeacherPolicy()
        {
            return new AuthorizationPolicyBuilder().RequireAuthenticatedUser()
                                                   .RequireRole("Teacher")
                                                   .Build();
        }

        public static AuthorizationPolicy IsStudentPolicy()
        {
            return new AuthorizationPolicyBuilder().RequireAuthenticatedUser()
                                                   .RequireRole("Student")
                                                   .Build();
        }
    }
}
