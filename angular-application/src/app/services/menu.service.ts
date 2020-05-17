import { Injectable } from '@angular/core';
import { Observable, throwError } from 'rxjs';
import { QueryBase, BaseSearch, QueryListResponse } from '@app/models';
import { Menu, ApiResponse } from '@app/models';
import { map, catchError } from 'rxjs/operators';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { BaseService } from '@app/services';
@Injectable({
  providedIn: 'root'
})
export class MenuService extends BaseService{

  private API_PREFIX = `${this.API_BASE_URL}/Menu`;
  constructor(private http : HttpClient) {
    super();
  }
  initListCategories(): Observable<Menu[]> {
    return this.getListCategories(this.getInitialInputSearch());
}

getListCategories(input: QueryBase<BaseSearch>): Observable<Menu[]> {
    const data = JSON.stringify(input);
    const config = { headers: new HttpHeaders().set('Content-Type', 'application/json') };

    return this.http
        .get<ApiResponse<QueryListResponse<Menu>>>(`${this.API_PREFIX}/`, data, config );
        .pipe(map(result => result.Result.Items), catchError(e => throwError(e.error)));
}
}
