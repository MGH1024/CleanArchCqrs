export default interface ICommandResponse{
    Success:boolean,
    Message :string,
    Id : number,
    Errors?: string[],
}