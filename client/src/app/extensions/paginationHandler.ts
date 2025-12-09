import { HttpClient, HttpParams } from "@angular/common/http";
import { map, Observable } from "rxjs";
import { PaginatedResult } from "../models/helpers/paginatedResult";
import { inject } from "@angular/core";

export class PaginationHandler {
    private http = inject(HttpClient);

    getPaginatedResult<T>(url: string, params: HttpParams): Observable<PaginatedResult<T>> {
        const paginatedResult = new PaginatedResult<T>();

        return this.http.get<T>(url, { observe: 'response', params })
            .pipe(
                map(response => {
                    const pagination: string | null = response.headers.get('Pagination');

                    if (pagination)
                        paginatedResult.pagination = JSON.parse(pagination);

                    if (response.body)
                        paginatedResult.body = response.body

                    return paginatedResult;
                })
            );
    }
}