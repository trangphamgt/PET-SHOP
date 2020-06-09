import { Injectable } from '@angular/core';
import { Observable, throwError } from 'rxjs';
import { QueryBase, BaseSearch, QueryListResponse } from '@app/models';
import { Menu, ApiResponse } from '@app/models';
import { map, catchError } from 'rxjs/operators';
import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { BaseService } from '@app/services';
@Injectable({
  providedIn: 'root'
})
export class MenuService extends BaseService{

  private API_PREFIX = `${this.API_BASE_URL}/Menu`;
  constructor(private http : HttpClient) {
    super();
  }


getMenubyRole(role: number): Observable<Menu[]> {
    return this.http.get<Menu[]>(`${this.API_PREFIX}/GetByRole?role=${role}`);
        
}
}
