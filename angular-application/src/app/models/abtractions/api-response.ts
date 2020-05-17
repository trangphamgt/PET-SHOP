export interface ApiResponse<T> {
    Version: string,
    StatusCode: number,
    Message: string,
    IsError: boolean,
    Result: T
}