export default interface IUpdateProduct {
    id: number | string | undefined,
    code: number,
    title: string,
    quantity: number,
    categoryId: number,
    description?: string,
} 