import { IProductTypePagination } from './../shared/models/pagination';
import { IBrandPagination, IPagination } from '../shared/models/pagination';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { map } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ShopService {
  baseUrl = 'https://localhost:7013/api/';

  constructor(private http: HttpClient) { }

  getProducts(brandId?: number, typeId?: number) {
    let params = new HttpParams();
    if (brandId) {
      params = params.append('brandId', brandId.toString());
    }
    if (typeId) {
      params = params.append('typeId', typeId.toString());
    }
    return this.http.get<IPagination>(this.baseUrl + 'products?PageSize=30', {observe: 'response', params})
      .pipe(
        map(response => {
          return response.body;
        }
      )
    );
  }

  getBrands() {
    return this.http.get<IBrandPagination>(this.baseUrl + 'products/brands');
  }

  getTypes() {
    return this.http.get<IProductTypePagination>(this.baseUrl + 'products/types');
  }

}
