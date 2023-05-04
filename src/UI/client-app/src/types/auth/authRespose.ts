export default interface IAuthResponse {
    Token: string,
    Success: boolean,
    RefreshToken: string,
    TokenValidDate?: Date,
    ReturnUrl?: string
    SuccessMessage: string,
    Errors: string[]
}