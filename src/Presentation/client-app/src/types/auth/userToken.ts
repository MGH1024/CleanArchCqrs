export default interface IUserToken {
    success: boolean,
    token: string,
    refreshToken: string,
    tokenValidDate?: Date,
    returnUrl?: string,
    successMessage?: string,
    errors?: Array<string>
}