import { Pagination } from "./pagination";

export class PaginatedResult<T> {
    pagination?: Pagination;
    body?: T;
}