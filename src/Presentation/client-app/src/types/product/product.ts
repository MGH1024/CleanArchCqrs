export default interface IProduct {
    Id: number,
    CategoryId: number,
    Code: number,
    CreatedDate: Date,
    Description?: string
    Order: number,
    Quantity: number,
    Title: string,
    CategoryTitle :string,
}
