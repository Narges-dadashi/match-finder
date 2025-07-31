export interface AppUser {
    email: string;
    userName: string;
    password: string;
    confirmPassword: string;
    dateOfBirth: string | undefined;
    city: string;
    country: string;
}